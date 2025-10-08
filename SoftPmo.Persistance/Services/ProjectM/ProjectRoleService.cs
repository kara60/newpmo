using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.CreateProjectRole;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.UpdateProjectRole;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Queries.GetAllProjectRoles;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.ProjectM;

public sealed class ProjectRoleService : IProjectRoleService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProjectRoleService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateProjectRoleCommandResponse> CreateAsync(CreateProjectRoleCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        ProjectRole projectRole = _mapper.Map<ProjectRole>(request);

        // Otomatik kod oluştur (PRJ-ROLE-001 formatında)
        var lastCode = await _context.Set<ProjectRole>()
            .Where(pr => pr.Code.StartsWith("PRJ-ROLE-"))
            .OrderByDescending(pr => pr.Code)
            .Select(pr => pr.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("PRJ-ROLE-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        projectRole.Code = $"PRJ-ROLE-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<ProjectRole>().AddAsync(projectRole, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateProjectRoleCommandResponse(projectRole.Id, projectRole.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateProjectRoleCommand request, CancellationToken cancellationToken)
    {
        // Mevcut projectRole'u bul
        ProjectRole? projectRole = await _context.Set<ProjectRole>()
            .FirstOrDefaultAsync(pr => pr.Id == request.Id, cancellationToken);

        if (projectRole is null)
            throw new Exception("Proje rolü bulunamadı.");

        // Güncelle
        projectRole.Name = request.Name;
        projectRole.IsActive = request.IsActive;
        projectRole.UpdatedDate = DateTime.UtcNow;

        _context.Set<ProjectRole>().Update(projectRole);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        ProjectRole? projectRole = await _context.Set<ProjectRole>()
            .Include(pr => pr.ProjectTeamMembers)
            .FirstOrDefaultAsync(pr => pr.Id == id, cancellationToken);

        if (projectRole is null)
            throw new Exception("Proje rolü bulunamadı.");

        // Bu rolde aktif ekip üyeleri var mı kontrol et
        if (projectRole.ProjectTeamMembers.Any(ptm => ptm.IsActive))
            throw new Exception("Bu rolde aktif proje ekip üyeleri var. Önce rolleri değiştirin.");

        // Soft delete
        projectRole.IsActive = false;
        projectRole.UpdatedDate = DateTime.UtcNow;

        _context.Set<ProjectRole>().Update(projectRole);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<ProjectRole>> GetAllAsync(GetAllProjectRolesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ProjectRole> query = _context.Set<ProjectRole>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(pr =>
                pr.Name.ToLower().Contains(searchLower) ||
                pr.Code.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(pr => pr.IsActive == request.IsActive.Value);
        }

        // Sayfalama
        var projectRoles = await query
            .OrderBy(pr => pr.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return projectRoles;
    }

    public async Task<ProjectRole> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        ProjectRole? projectRole = await _context.Set<ProjectRole>()
            .FirstOrDefaultAsync(pr => pr.Id == id, cancellationToken);

        if (projectRole is null)
            throw new Exception("Proje rolü bulunamadı.");

        return projectRole;
    }
}