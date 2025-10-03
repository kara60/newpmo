using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.CreateDepartment;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.UpdateDepartment;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Queries.GetAllDepartments;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.SystemBase;

public sealed class DepartmentService : IDepartmentService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public DepartmentService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateDepartmentCommandResponse> CreateAsync(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        Department department = _mapper.Map<Department>(request);

        // Otomatik kod oluştur (DEPT-001 formatında)
        var lastCode = await _context.Set<Department>()
            .Where(d => d.Code.StartsWith("DEPT-"))
            .OrderByDescending(d => d.Code)
            .Select(d => d.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("DEPT-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        department.Code = $"DEPT-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<Department>().AddAsync(department, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateDepartmentCommandResponse(department.Id, department.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        // Mevcut department'ı bul
        Department? department = await _context.Set<Department>()
            .FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);

        if (department is null)
            throw new Exception("Departman bulunamadı.");

        // Circular reference kontrolü
        if (!string.IsNullOrEmpty(request.ParentDepartmentId))
        {
            bool hasCircular = await CheckCircularReference(request.Id, request.ParentDepartmentId, cancellationToken);
            if (hasCircular)
                throw new Exception("Döngüsel hiyerarşi oluşturulamaz.");
        }

        // Güncelle
        department.Name = request.Name;
        department.ParentDepartmentId = request.ParentDepartmentId;
        department.ManagerId = request.ManagerId;
        department.LocationId = request.LocationId;
        department.IsActive = request.IsActive;
        department.UpdatedDate = DateTime.UtcNow;

        _context.Set<Department>().Update(department);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Department? department = await _context.Set<Department>()
            .Include(d => d.SubDepartments)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

        if (department is null)
            throw new Exception("Departman bulunamadı.");

        // Alt departmanları kontrol et
        if (department.SubDepartments.Any())
            throw new Exception("Bu departmanın alt departmanları var. Önce alt departmanları silin veya taşıyın.");

        // Soft delete
        department.IsActive = false;
        department.UpdatedDate = DateTime.UtcNow;

        _context.Set<Department>().Update(department);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Department>> GetAllAsync(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Department> query = _context.Set<Department>()
            .Include(d => d.ParentDepartment)
            .Include(d => d.Manager)
            .Include(d => d.Location)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(d =>
                d.Name.ToLower().Contains(searchLower) ||
                d.Code.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(d => d.IsActive == request.IsActive.Value);
        }

        // Parent department filtresi
        if (!string.IsNullOrEmpty(request.ParentDepartmentId))
        {
            query = query.Where(d => d.ParentDepartmentId == request.ParentDepartmentId);
        }

        // Sayfalama
        var departments = await query
            .OrderBy(d => d.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return departments;
    }

    public async Task<Department> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Department? department = await _context.Set<Department>()
            .Include(d => d.ParentDepartment)
            .Include(d => d.Manager)
            .Include(d => d.Location)
            .Include(d => d.SubDepartments)
            .Include(d => d.Positions)
            .Include(d => d.Users)
            .FirstOrDefaultAsync(d => d.Id == id, cancellationToken);

        if (department is null)
            throw new Exception("Departman bulunamadı.");

        return department;
    }

    public async Task<IList<Department>> GetHierarchyAsync(CancellationToken cancellationToken)
    {
        // Root departmanları getir (ParentDepartmentId == null olanlar)
        var rootDepartments = await _context.Set<Department>()
            .Include(d => d.Manager)
            .Include(d => d.Location)
            .Include(d => d.SubDepartments)
                .ThenInclude(sd => sd.SubDepartments)
                    .ThenInclude(sd => sd.SubDepartments) // 3 seviye
            .Where(d => d.ParentDepartmentId == null && d.IsActive)
            .OrderBy(d => d.Name)
            .ToListAsync(cancellationToken);

        return rootDepartments;
    }

    // Circular reference kontrolü
    private async Task<bool> CheckCircularReference(string departmentId, string parentId, CancellationToken cancellationToken)
    {
        var parent = await _context.Set<Department>()
            .FirstOrDefaultAsync(d => d.Id == parentId, cancellationToken);

        if (parent is null) return false;

        // Eğer parent'ın parent'ı bizim departmanımızsa döngü var
        if (parent.ParentDepartmentId == departmentId) return true;

        // Recursive kontrol
        if (!string.IsNullOrEmpty(parent.ParentDepartmentId))
        {
            return await CheckCircularReference(departmentId, parent.ParentDepartmentId, cancellationToken);
        }

        return false;
    }
}