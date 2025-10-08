using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Queries.GetAllProjectTypes;

public sealed class GetAllProjectTypesQueryHandler : IRequestHandler<GetAllProjectTypesQuery, IList<ProjectType>>
{
    private readonly IProjectTypeService _projectTypeService;

    public GetAllProjectTypesQueryHandler(IProjectTypeService projectTypeService)
    {
        _projectTypeService = projectTypeService;
    }

    public async Task<IList<ProjectType>> Handle(GetAllProjectTypesQuery request, CancellationToken cancellationToken)
    {
        var projectTypes = await _projectTypeService.GetAllAsync(request, cancellationToken);
        return projectTypes;
    }
}