using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.CreateUser;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.UpdateUser;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetAllUsers;
using SoftPmo.Application.Services.HumanResources;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.HumanResources;

public sealed class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public UserService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateUserCommandResponse> CreateAsync(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Department kontrolü
        var departmentExists = await _context.Set<Department>()
            .AnyAsync(d => d.Id == request.DepartmentId && d.IsActive, cancellationToken);

        if (!departmentExists)
            throw new Exception("Departman bulunamadı veya aktif değil.");

        // Position kontrolü
        var positionExists = await _context.Set<Position>()
            .AnyAsync(p => p.Id == request.PositionId && p.IsActive, cancellationToken);

        if (!positionExists)
            throw new Exception("Pozisyon bulunamadı veya aktif değil.");

        // DirectManager kontrolü (opsiyonel)
        if (!string.IsNullOrEmpty(request.DirectManagerId))
        {
            var managerExists = await _context.Set<User>()
                .AnyAsync(u => u.Id == request.DirectManagerId && u.IsActive, cancellationToken);

            if (!managerExists)
                throw new Exception("Direkt yönetici bulunamadı veya aktif değil.");
        }

        // Email benzersizliği kontrolü
        var emailExists = await _context.Set<User>()
            .AnyAsync(u => u.Email.ToLower() == request.Email.ToLower(), cancellationToken);

        if (emailExists)
            throw new Exception($"'{request.Email}' email adresi zaten kullanılıyor.");

        // Mapping
        User user = _mapper.Map<User>(request);

        // Otomatik kod oluştur (PMO-2025-001 formatında)
        var year = DateTime.Now.Year;
        var lastCode = await _context.Set<User>()
            .Where(u => u.Code.StartsWith($"PMO-{year}-"))
            .OrderByDescending(u => u.Code)
            .Select(u => u.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace($"PMO-{year}-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        user.Code = $"PMO-{year}-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<User>().AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateUserCommandResponse(user.Id, user.Code, user.FullName);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        // Mevcut user'ı bul
        User? user = await _context.Set<User>()
            .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

        if (user is null)
            throw new Exception("Personel bulunamadı.");

        // Department kontrolü
        var departmentExists = await _context.Set<Department>()
            .AnyAsync(d => d.Id == request.DepartmentId && d.IsActive, cancellationToken);

        if (!departmentExists)
            throw new Exception("Departman bulunamadı veya aktif değil.");

        // Position kontrolü
        var positionExists = await _context.Set<Position>()
            .AnyAsync(p => p.Id == request.PositionId && p.IsActive, cancellationToken);

        if (!positionExists)
            throw new Exception("Pozisyon bulunamadı veya aktif değil.");

        // DirectManager kontrolü (opsiyonel)
        if (!string.IsNullOrEmpty(request.DirectManagerId))
        {
            // Kendisini yönetici olarak seçemez
            if (request.DirectManagerId == request.Id)
                throw new Exception("Bir personel kendisini yönetici olarak seçemez.");

            var managerExists = await _context.Set<User>()
                .AnyAsync(u => u.Id == request.DirectManagerId && u.IsActive, cancellationToken);

            if (!managerExists)
                throw new Exception("Direkt yönetici bulunamadı veya aktif değil.");
        }

        // Email benzersizliği kontrolü (kendisi hariç)
        var emailExists = await _context.Set<User>()
            .AnyAsync(u => u.Email.ToLower() == request.Email.ToLower() && u.Id != request.Id, cancellationToken);

        if (emailExists)
            throw new Exception($"'{request.Email}' email adresi zaten kullanılıyor.");

        // Güncelle
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        user.Phone = request.Phone;
        user.StartDate = request.StartDate;
        user.DepartmentId = request.DepartmentId;
        user.PositionId = request.PositionId;
        user.DirectManagerId = request.DirectManagerId;
        user.BillingMultiplier = request.BillingMultiplier;
        user.IsActive = request.IsActive;
        user.UpdatedDate = DateTime.UtcNow;

        _context.Set<User>().Update(user);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        User? user = await _context.Set<User>()
            .Include(u => u.ManagedProjects)
            .Include(u => u.MainResponsibleTasks)
            .Include(u => u.Subordinates)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (user is null)
            throw new Exception("Personel bulunamadı.");

        // Bu personel proje müdürü mü kontrol et
        if (user.ManagedProjects.Any(p => p.IsActive))
            throw new Exception("Bu personel aktif projelerin müdürü. Önce projeleri başkasına atayın.");

        // Bu personel işlerin sorumlusu mu kontrol et
        if (user.MainResponsibleTasks.Any(t => t.IsActive))
            throw new Exception("Bu personelin aktif işleri var. Önce işleri başkasına atayın.");

        // Bu personel başkalarının yöneticisi mi kontrol et
        if (user.Subordinates.Any(s => s.IsActive))
            throw new Exception("Bu personel başkalarının yöneticisi. Önce yöneticilik ilişkilerini düzeltin.");

        // Soft delete
        user.IsActive = false;
        user.UpdatedDate = DateTime.UtcNow;

        _context.Set<User>().Update(user);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<User>> GetAllAsync(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<User> query = _context.Set<User>()
            .Include(u => u.Department)
            .Include(u => u.Position)
            .Include(u => u.DirectManager)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(u =>
                u.FirstName.ToLower().Contains(searchLower) ||
                u.LastName.ToLower().Contains(searchLower) ||
                u.Code.ToLower().Contains(searchLower) ||
                u.Email.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(u => u.IsActive == request.IsActive.Value);
        }

        // Departman filtresi
        if (!string.IsNullOrEmpty(request.DepartmentId))
        {
            query = query.Where(u => u.DepartmentId == request.DepartmentId);
        }

        // Pozisyon filtresi
        if (!string.IsNullOrEmpty(request.PositionId))
        {
            query = query.Where(u => u.PositionId == request.PositionId);
        }

        // Sayfalama
        var users = await query
            .OrderBy(u => u.Department.Name)
            .ThenBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return users;
    }

    public async Task<User> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        User? user = await _context.Set<User>()
            .Include(u => u.Department)
            .Include(u => u.Position)
            .Include(u => u.DirectManager)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (user is null)
            throw new Exception("Personel bulunamadı.");

        return user;
    }

    public async Task<IList<User>> GetByDepartmentAsync(string departmentId, CancellationToken cancellationToken)
    {
        var users = await _context.Set<User>()
            .Include(u => u.Position)
            .Where(u => u.DepartmentId == departmentId && u.IsActive)
            .OrderBy(u => u.FirstName)
            .ThenBy(u => u.LastName)
            .ToListAsync(cancellationToken);

        return users;
    }

    public async Task<User> GetWithDetailsAsync(string id, CancellationToken cancellationToken)
    {
        User? user = await _context.Set<User>()
            .Include(u => u.Department)
            .Include(u => u.Position)
                .ThenInclude(p => p.PositionLevel)
            .Include(u => u.DirectManager)
            .Include(u => u.Subordinates.Where(s => s.IsActive))
            .Include(u => u.ManagedProjects.Where(p => p.IsActive))
                .ThenInclude(p => p.ProjectStatus)
            .Include(u => u.MainResponsibleTasks.Where(t => t.IsActive))
                .ThenInclude(t => t.TaskStatus)
            .Include(u => u.ProjectMemberships.Where(pm => pm.IsActive))
                .ThenInclude(pm => pm.Project)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);

        if (user is null)
            throw new Exception("Personel bulunamadı.");

        return user;
    }
}