using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.CreateProjectStatus;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.UpdateProjectStatus;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Queries.GetAllProjectStatuses;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.ProjectM;

public sealed class ProjectStatusService : IProjectStatusService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProjectStatusService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateProjectStatusCommandResponse> CreateAsync(CreateProjectStatusCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        ProjectStatus projectStatus = _mapper.Map<ProjectStatus>(request);

        // Otomatik kod oluştur (PRJ-ST-001 formatında)
        var lastCode = await _context.Set<ProjectStatus>()
            .Where(ps => ps.Code.StartsWith("PRJ-ST-"))
            .OrderByDescending(ps => ps.Code)
            .Select(ps => ps.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("PRJ-ST-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        projectStatus.Code = $"PRJ-ST-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<ProjectStatus>().AddAsync(projectStatus, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateProjectStatusCommandResponse(projectStatus.Id, projectStatus.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateProjectStatusCommand request, CancellationToken cancellationToken)
    {
        // Mevcut projectStatus'u bul
        ProjectStatus? projectStatus = await _context.Set<ProjectStatus>()
            .FirstOrDefaultAsync(ps => ps.Id == request.Id, cancellationToken);

        if (projectStatus is null)
            throw new Exception("Proje durumu bulunamadı.");

        // Güncelle
        projectStatus.Name = request.Name;
        projectStatus.SortOrder = request.SortOrder;
        projectStatus.ColorCode = request.ColorCode;
        projectStatus.IsActive = request.IsActive;
        projectStatus.UpdatedDate = DateTime.UtcNow;

        _context.Set<ProjectStatus>().Update(projectStatus);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        ProjectStatus? projectStatus = await _context.Set<ProjectStatus>()
            .Include(ps => ps.Projects)
            .FirstOrDefaultAsync(ps => ps.Id == id, cancellationToken);

        if (projectStatus is null)
            throw new Exception("Proje durumu bulunamadı.");

        // Bu durumda aktif projeler var mı kontrol et
        if (projectStatus.Projects.Any(p => p.IsActive))
            throw new Exception("Bu durumda aktif projeler var. Önce projeleri taşıyın.");

        // Soft delete
        projectStatus.IsActive = false;
        projectStatus.UpdatedDate = DateTime.UtcNow;

        _context.Set<ProjectStatus>().Update(projectStatus);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<ProjectStatus>> GetAllAsync(GetAllProjectStatusesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ProjectStatus> query = _context.Set<ProjectStatus>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(ps =>
                ps.Name.ToLower().Contains(searchLower) ||
                ps.Code.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(ps => ps.IsActive == request.IsActive.Value);
        }

        //// StatusType filtresi
        //if (!string.IsNullOrEmpty(request.StatusType))
        //{
        //    query = query.Where(ps => ps.StatusType == request.StatusType);
        //}

        // Sayfalama
        var projectStatuses = await query
            .OrderBy(ps => ps.SortOrder)
            .ThenBy(ps => ps.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return projectStatuses;
    }

    public async Task<ProjectStatus> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        ProjectStatus? projectStatus = await _context.Set<ProjectStatus>()
            .FirstOrDefaultAsync(ps => ps.Id == id, cancellationToken);

        if (projectStatus is null)
            throw new Exception("Proje durumu bulunamadı.");

        return projectStatus;
    }
}