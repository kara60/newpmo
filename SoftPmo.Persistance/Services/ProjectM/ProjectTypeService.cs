using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.CreateProjectType;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.UpdateProjectType;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Queries.GetAllProjectTypes;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.ProjectM;

public sealed class ProjectTypeService : IProjectTypeService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProjectTypeService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateProjectTypeCommandResponse> CreateAsync(CreateProjectTypeCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        ProjectType projectType = _mapper.Map<ProjectType>(request);

        // Otomatik kod oluştur (PRJ-TYPE-001 formatında)
        var lastCode = await _context.Set<ProjectType>()
            .Where(pt => pt.Code.StartsWith("PRJ-TYPE-"))
            .OrderByDescending(pt => pt.Code)
            .Select(pt => pt.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("PRJ-TYPE-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        projectType.Code = $"PRJ-TYPE-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<ProjectType>().AddAsync(projectType, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateProjectTypeCommandResponse(projectType.Id, projectType.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateProjectTypeCommand request, CancellationToken cancellationToken)
    {
        // Mevcut projectType'ı bul
        ProjectType? projectType = await _context.Set<ProjectType>()
            .FirstOrDefaultAsync(pt => pt.Id == request.Id, cancellationToken);

        if (projectType is null)
            throw new Exception("Proje tipi bulunamadı.");

        // Güncelle
        projectType.Name = request.Name;
        projectType.Category = request.Category;
        projectType.DefaultDurationDays = (int)request.DefaultDurationDays;
        projectType.ColorCode = request.ColorCode;
        projectType.IsActive = request.IsActive;
        projectType.UpdatedDate = DateTime.UtcNow;

        _context.Set<ProjectType>().Update(projectType);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        ProjectType? projectType = await _context.Set<ProjectType>()
            .Include(pt => pt.Projects)
            .FirstOrDefaultAsync(pt => pt.Id == id, cancellationToken);

        if (projectType is null)
            throw new Exception("Proje tipi bulunamadı.");

        // Bu tipte aktif projeler var mı kontrol et
        if (projectType.Projects.Any(p => p.IsActive))
            throw new Exception("Bu tipte aktif projeler var. Önce projeleri taşıyın.");

        // Soft delete
        projectType.IsActive = false;
        projectType.UpdatedDate = DateTime.UtcNow;

        _context.Set<ProjectType>().Update(projectType);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<ProjectType>> GetAllAsync(GetAllProjectTypesQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ProjectType> query = _context.Set<ProjectType>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(pt =>
                pt.Name.ToLower().Contains(searchLower) ||
                pt.Code.ToLower().Contains(searchLower) ||
                (pt.Category != null && pt.Category.ToLower().Contains(searchLower))
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(pt => pt.IsActive == request.IsActive.Value);
        }

        // Kategori filtresi
        if (!string.IsNullOrEmpty(request.Category))
        {
            query = query.Where(pt => pt.Category == request.Category);
        }

        // Sayfalama
        var projectTypes = await query
            .OrderBy(pt => pt.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return projectTypes;
    }

    public async Task<ProjectType> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        ProjectType? projectType = await _context.Set<ProjectType>()
            .FirstOrDefaultAsync(pt => pt.Id == id, cancellationToken);

        if (projectType is null)
            throw new Exception("Proje tipi bulunamadı.");

        return projectType;
    }
}