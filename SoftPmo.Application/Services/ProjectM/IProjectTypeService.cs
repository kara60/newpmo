using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.CreateProjectType;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.UpdateProjectType;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Queries.GetAllProjectTypes;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Services.ProjectM;

public interface IProjectTypeService
{
    Task<CreateProjectTypeCommandResponse> CreateAsync(CreateProjectTypeCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateProjectTypeCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<ProjectType>> GetAllAsync(GetAllProjectTypesQuery request, CancellationToken cancellationToken);
    Task<ProjectType> GetByIdAsync(string id, CancellationToken cancellationToken);
}