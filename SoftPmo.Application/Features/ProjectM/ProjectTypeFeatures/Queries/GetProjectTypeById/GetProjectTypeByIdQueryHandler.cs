using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Queries.GetProjectTypeById;

public sealed class GetProjectTypeByIdQueryHandler : IRequestHandler<GetProjectTypeByIdQuery, ProjectType>
{
    private readonly IProjectTypeService _projectTypeService;

    public GetProjectTypeByIdQueryHandler(IProjectTypeService projectTypeService)
    {
        _projectTypeService = projectTypeService;
    }

    public async Task<ProjectType> Handle(GetProjectTypeByIdQuery request, CancellationToken cancellationToken)
    {
        var projectType = await _projectTypeService.GetByIdAsync(request.Id, cancellationToken);
        return projectType;
    }
}