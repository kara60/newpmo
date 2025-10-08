using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.CreateProject;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.UpdateProject;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetAllProjects;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Services.ProjectM;

public interface IProjectService
{
    Task<CreateProjectCommandResponse> CreateAsync(CreateProjectCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateProjectCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Project.ProjectM>> GetAllAsync(GetAllProjectsQuery request, CancellationToken cancellationToken);
    Task<Domain.Entities.Project.ProjectM> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Project.ProjectM>> GetByCustomerAsync(string customerId, CancellationToken cancellationToken);
    Task<Domain.Entities.Project.ProjectM> GetWithDetailsAsync(string id, CancellationToken cancellationToken);
}