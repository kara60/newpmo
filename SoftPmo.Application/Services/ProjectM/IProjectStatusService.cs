using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.CreateProjectStatus;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.UpdateProjectStatus;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Queries.GetAllProjectStatuses;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Services.ProjectM;

public interface IProjectStatusService
{
    Task<CreateProjectStatusCommandResponse> CreateAsync(CreateProjectStatusCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateProjectStatusCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<ProjectStatus>> GetAllAsync(GetAllProjectStatusesQuery request, CancellationToken cancellationToken);
    Task<ProjectStatus> GetByIdAsync(string id, CancellationToken cancellationToken);
}