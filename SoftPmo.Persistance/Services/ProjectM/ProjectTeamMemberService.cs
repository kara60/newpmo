using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.CreateProjectTeamMember;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.UpdateProjectTeamMember;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetAllProjectTeamMembers;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.ProjectM;

public sealed class ProjectTeamMemberService : IProjectTeamMemberService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public ProjectTeamMemberService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateProjectTeamMemberCommandResponse> CreateAsync(CreateProjectTeamMemberCommand request, CancellationToken cancellationToken)
    {
        // Project kontrolü
        var projectExists = await _context.Set<Domain.Entities.Project.ProjectM>()
            .AnyAsync(p => p.Id == request.ProjectId && p.IsActive, cancellationToken);

        if (!projectExists)
            throw new Exception("Proje bulunamadı veya aktif değil.");

        // User kontrolü
        var userExists = await _context.Set<User>()
            .AnyAsync(u => u.Id == request.UserId && u.IsActive, cancellationToken);

        if (!userExists)
            throw new Exception("Personel bulunamadı veya aktif değil.");

        // ProjectRole kontrolü
        var projectRoleExists = await _context.Set<ProjectRole>()
            .AnyAsync(pr => pr.Id == request.ProjectRoleId && pr.IsActive, cancellationToken);

        if (!projectRoleExists)
            throw new Exception("Proje rolü bulunamadı veya aktif değil.");

        // Aynı personel aynı projede zaten var mı kontrolü
        var memberExists = await _context.Set<ProjectTeamMember>()
            .AnyAsync(ptm => ptm.ProjectId == request.ProjectId &&
                           ptm.UserId == request.UserId &&
                           ptm.IsActive, cancellationToken);

        if (memberExists)
            throw new Exception("Bu personel zaten proje ekibinde.");

        // Mapping
        ProjectTeamMember projectTeamMember = _mapper.Map<ProjectTeamMember>(request);

        // Otomatik kod oluştur (PRJ-TEAM-001 formatında)
        var lastCode = await _context.Set<ProjectTeamMember>()
            .Where(ptm => ptm.Code.StartsWith("PRJ-TEAM-"))
            .OrderByDescending(ptm => ptm.Code)
            .Select(ptm => ptm.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("PRJ-TEAM-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        projectTeamMember.Code = $"PRJ-TEAM-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<ProjectTeamMember>().AddAsync(projectTeamMember, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateProjectTeamMemberCommandResponse(projectTeamMember.Id, projectTeamMember.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateProjectTeamMemberCommand request, CancellationToken cancellationToken)
    {
        // Mevcut projectTeamMember'ı bul
        ProjectTeamMember? projectTeamMember = await _context.Set<ProjectTeamMember>()
            .FirstOrDefaultAsync(ptm => ptm.Id == request.Id, cancellationToken);

        if (projectTeamMember is null)
            throw new Exception("Proje ekip üyesi bulunamadı.");

        // Project kontrolü
        var projectExists = await _context.Set<Domain.Entities.Project.ProjectM>()
            .AnyAsync(p => p.Id == request.ProjectId && p.IsActive, cancellationToken);

        if (!projectExists)
            throw new Exception("Proje bulunamadı veya aktif değil.");

        // User kontrolü
        var userExists = await _context.Set<User>()
            .AnyAsync(u => u.Id == request.UserId && u.IsActive, cancellationToken);

        if (!userExists)
            throw new Exception("Personel bulunamadı veya aktif değil.");

        // ProjectRole kontrolü
        var projectRoleExists = await _context.Set<ProjectRole>()
            .AnyAsync(pr => pr.Id == request.ProjectRoleId && pr.IsActive, cancellationToken);

        if (!projectRoleExists)
            throw new Exception("Proje rolü bulunamadı veya aktif değil.");

        // Aynı personel aynı projede başka kayıtta var mı kontrolü (kendisi hariç)
        var duplicateExists = await _context.Set<ProjectTeamMember>()
            .AnyAsync(ptm => ptm.ProjectId == request.ProjectId &&
                           ptm.UserId == request.UserId &&
                           ptm.IsActive &&
                           ptm.Id != request.Id, cancellationToken);

        if (duplicateExists)
            throw new Exception("Bu personel zaten proje ekibinde başka bir kayıtta var.");

        // Güncelle
        projectTeamMember.ProjectId = request.ProjectId;
        projectTeamMember.UserId = request.UserId;
        projectTeamMember.ProjectRoleId = request.ProjectRoleId;
        projectTeamMember.JoinDate = request.JoinedDate;
        projectTeamMember.LeaveDate = request.LeftDate;
        projectTeamMember.IsActive = request.IsActive;
        projectTeamMember.UpdatedDate = DateTime.UtcNow;

        _context.Set<ProjectTeamMember>().Update(projectTeamMember);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        ProjectTeamMember? projectTeamMember = await _context.Set<ProjectTeamMember>()
            .FirstOrDefaultAsync(ptm => ptm.Id == id, cancellationToken);

        if (projectTeamMember is null)
            throw new Exception("Proje ekip üyesi bulunamadı.");

        // Soft delete
        projectTeamMember.IsActive = false;
        projectTeamMember.UpdatedDate = DateTime.UtcNow;

        _context.Set<ProjectTeamMember>().Update(projectTeamMember);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<ProjectTeamMember>> GetAllAsync(GetAllProjectTeamMembersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<ProjectTeamMember> query = _context.Set<ProjectTeamMember>()
            .Include(ptm => ptm.Project)
            .Include(ptm => ptm.User)
            .Include(ptm => ptm.ProjectRole)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(ptm =>
                ptm.Code.ToLower().Contains(searchLower) ||
                ptm.User.FirstName.ToLower().Contains(searchLower) ||
                ptm.User.LastName.ToLower().Contains(searchLower) ||
                ptm.Project.Name.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(ptm => ptm.IsActive == request.IsActive.Value);
        }

        // Proje filtresi
        if (!string.IsNullOrEmpty(request.ProjectId))
        {
            query = query.Where(ptm => ptm.ProjectId == request.ProjectId);
        }

        // Personel filtresi
        if (!string.IsNullOrEmpty(request.UserId))
        {
            query = query.Where(ptm => ptm.UserId == request.UserId);
        }

        // Sayfalama
        var projectTeamMembers = await query
            .OrderBy(ptm => ptm.Project.Name)
            .ThenBy(ptm => ptm.User.FirstName)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return projectTeamMembers;
    }

    public async Task<ProjectTeamMember> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        ProjectTeamMember? projectTeamMember = await _context.Set<ProjectTeamMember>()
            .Include(ptm => ptm.Project)
            .Include(ptm => ptm.User)
            .Include(ptm => ptm.ProjectRole)
            .FirstOrDefaultAsync(ptm => ptm.Id == id, cancellationToken);

        if (projectTeamMember is null)
            throw new Exception("Proje ekip üyesi bulunamadı.");

        return projectTeamMember;
    }

    public async Task<IList<ProjectTeamMember>> GetByProjectAsync(string projectId, CancellationToken cancellationToken)
    {
        var projectTeamMembers = await _context.Set<ProjectTeamMember>()
            .Include(ptm => ptm.User)
            .Include(ptm => ptm.ProjectRole)
            .Where(ptm => ptm.ProjectId == projectId && ptm.IsActive)
            .OrderBy(ptm => ptm.JoinDate)
            .ToListAsync(cancellationToken);

        return projectTeamMembers;
    }
}