using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.CreateProject;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.UpdateProject;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetAllProjects;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.ProjectM;

public sealed class ProjectService : IProjectService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProjectService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateProjectCommandResponse> CreateAsync(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        // Customer kontrolü
        var customerExists = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .AnyAsync(c => c.Id == request.CustomerId && c.IsActive, cancellationToken);

        if (!customerExists)
            throw new Exception("Müşteri bulunamadı veya aktif değil.");

        // ProjectType kontrolü
        var projectTypeExists = await _context.Set<ProjectType>()
            .AnyAsync(pt => pt.Id == request.ProjectTypeId && pt.IsActive, cancellationToken);

        if (!projectTypeExists)
            throw new Exception("Proje tipi bulunamadı veya aktif değil.");

        // ProjectManager kontrolü
        var projectManagerExists = await _context.Set<User>()
            .AnyAsync(u => u.Id == request.ProjectManagerId && u.IsActive, cancellationToken);

        if (!projectManagerExists)
            throw new Exception("Proje müdürü bulunamadı veya aktif değil.");

        // ProjectStatus kontrolü
        var projectStatusExists = await _context.Set<ProjectStatus>()
            .AnyAsync(ps => ps.Id == request.ProjectStatusId && ps.IsActive, cancellationToken);

        if (!projectStatusExists)
            throw new Exception("Proje durumu bulunamadı veya aktif değil.");

        // Priority kontrolü (opsiyonel)
        if (!string.IsNullOrEmpty(request.PriorityId))
        {
            var priorityExists = await _context.Set<Priority>()
                .AnyAsync(p => p.Id == request.PriorityId && p.IsActive, cancellationToken);

            if (!priorityExists)
                throw new Exception("Öncelik bulunamadı veya aktif değil.");
        }

        // Mapping
        Domain.Entities.Project.ProjectM project = _mapper.Map<Domain.Entities.Project.ProjectM>(request);

        // Otomatik kod oluştur (PRJ-001 formatında)
        var lastCode = await _context.Set<Domain.Entities.Project.ProjectM>()
            .Where(p => p.Code.StartsWith("PRJ-"))
            .OrderByDescending(p => p.Code)
            .Select(p => p.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("PRJ-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        project.Code = $"PRJ-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<Domain.Entities.Project.ProjectM>().AddAsync(project, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateProjectCommandResponse(project.Id, project.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        // Mevcut project'i bul
        Domain.Entities.Project.ProjectM? project = await _context.Set<Domain.Entities.Project.ProjectM>()
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        if (project is null)
            throw new Exception("Proje bulunamadı.");

        // Customer kontrolü
        var customerExists = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .AnyAsync(c => c.Id == request.CustomerId && c.IsActive, cancellationToken);

        if (!customerExists)
            throw new Exception("Müşteri bulunamadı veya aktif değil.");

        // ProjectType kontrolü
        var projectTypeExists = await _context.Set<ProjectType>()
            .AnyAsync(pt => pt.Id == request.ProjectTypeId && pt.IsActive, cancellationToken);

        if (!projectTypeExists)
            throw new Exception("Proje tipi bulunamadı veya aktif değil.");

        // ProjectManager kontrolü
        var projectManagerExists = await _context.Set<User>()
            .AnyAsync(u => u.Id == request.ProjectManagerId && u.IsActive, cancellationToken);

        if (!projectManagerExists)
            throw new Exception("Proje müdürü bulunamadı veya aktif değil.");

        // ProjectStatus kontrolü
        var projectStatusExists = await _context.Set<ProjectStatus>()
            .AnyAsync(ps => ps.Id == request.ProjectStatusId && ps.IsActive, cancellationToken);

        if (!projectStatusExists)
            throw new Exception("Proje durumu bulunamadı veya aktif değil.");

        // Priority kontrolü (opsiyonel)
        if (!string.IsNullOrEmpty(request.PriorityId))
        {
            var priorityExists = await _context.Set<Priority>()
                .AnyAsync(p => p.Id == request.PriorityId && p.IsActive, cancellationToken);

            if (!priorityExists)
                throw new Exception("Öncelik bulunamadı veya aktif değil.");
        }

        // Güncelle
        project.Name = request.Name;
        project.CustomerId = request.CustomerId;
        project.ProjectTypeId = request.ProjectTypeId;
        project.ProjectManagerId = request.ProjectManagerId;
        project.StartDate = request.StartDate;
        //project.PlannedEndDate = request.PlannedEndDate;
        project.ActualEndDate = request.ActualEndDate;
        //project.EstimatedDurationDays = request.EstimatedDurationDays;
        project.ProjectStatusId = request.ProjectStatusId;
        project.PriorityId = request.PriorityId;
        project.IsActive = request.IsActive;
        project.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Project.ProjectM>().Update(project);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Project.ProjectM? project = await _context.Set<Domain.Entities.Project.ProjectM>()
            .Include(p => p.Tasks)
            .Include(p => p.TeamMembers)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (project is null)
            throw new Exception("Proje bulunamadı.");

        // Bu projede aktif işler var mı kontrol et
        if (project.Tasks.Any(t => t.IsActive))
            throw new Exception("Bu projede aktif işler var. Önce işleri kapatın.");

        // Soft delete
        project.IsActive = false;
        project.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Project.ProjectM>().Update(project);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Domain.Entities.Project.ProjectM>> GetAllAsync(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Project.ProjectM> query = _context.Set<Domain.Entities.Project.ProjectM>()
            .Include(p => p.Customer)
            .Include(p => p.ProjectType)
            .Include(p => p.ProjectManager)
            .Include(p => p.ProjectStatus)
            .Include(p => p.Priority)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(p =>
                p.Name.ToLower().Contains(searchLower) ||
                p.Code.ToLower().Contains(searchLower) ||
                p.Customer.Name.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(p => p.IsActive == request.IsActive.Value);
        }

        // Müşteri filtresi
        if (!string.IsNullOrEmpty(request.CustomerId))
        {
            query = query.Where(p => p.CustomerId == request.CustomerId);
        }

        // Proje müdürü filtresi
        if (!string.IsNullOrEmpty(request.ProjectManagerId))
        {
            query = query.Where(p => p.ProjectManagerId == request.ProjectManagerId);
        }

        // Proje durumu filtresi
        if (!string.IsNullOrEmpty(request.ProjectStatusId))
        {
            query = query.Where(p => p.ProjectStatusId == request.ProjectStatusId);
        }

        // Sayfalama
        var projects = await query
            .OrderByDescending(p => p.CreatedDate)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return projects;
    }

    public async Task<Domain.Entities.Project.ProjectM> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Project.ProjectM? project = await _context.Set<Domain.Entities.Project.ProjectM>()
            .Include(p => p.Customer)
            .Include(p => p.ProjectType)
            .Include(p => p.ProjectManager)
            .Include(p => p.ProjectStatus)
            .Include(p => p.Priority)
            .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        if (project is null)
            throw new Exception("Proje bulunamadı.");

        return project;
    }

    public async Task<IList<Domain.Entities.Project.ProjectM>> GetByCustomerAsync(string customerId, CancellationToken cancellationToken)
    {
        var projects = await _context.Set<Domain.Entities.Project.ProjectM>()
            .Include(p => p.ProjectType)
            .Include(p => p.ProjectManager)
            .Include(p => p.ProjectStatus)
            .Where(p => p.CustomerId == customerId && p.IsActive)
            .OrderByDescending(p => p.StartDate)
            .ToListAsync(cancellationToken);

        return projects;
    }

    public async Task<Domain.Entities.Project.ProjectM> GetWithDetailsAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Project.ProjectM? project = await _context.Set<Domain.Entities.Project.ProjectM>()
        .Include(p => p.Customer)
        .Include(p => p.ProjectType)
        .Include(p => p.ProjectManager)
        .Include(p => p.ProjectStatus)
        .Include(p => p.Priority)
        .Include(p => p.TeamMembers.Where(ptm => ptm.IsActive))
        .ThenInclude(ptm => ptm.User)
        .Include(p => p.TeamMembers.Where(ptm => ptm.IsActive))
        .ThenInclude(ptm => ptm.ProjectRole)
        .Include(p => p.Tasks.Where(t => t.IsActive))
        .ThenInclude(t => t.TaskStatus)
        .Include(p => p.Tasks.Where(t => t.IsActive))
        .ThenInclude(t => t.MainResponsibleUser)
        .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        if (project is null)
            throw new Exception("Proje bulunamadı.");

        return project;
    }
}