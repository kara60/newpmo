using MediatR;
using SoftPmo.Application.Services.ProjectM;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetProjectsByCustomer;

public sealed class GetProjectsByCustomerQueryHandler : IRequestHandler<GetProjectsByCustomerQuery, IList<Domain.Entities.Project.ProjectM>>
{
    private readonly IProjectService _projectService;

    public GetProjectsByCustomerQueryHandler(IProjectService projectService)
    {
        _projectService = projectService;
    }

    public async Task<IList<Domain.Entities.Project.ProjectM>> Handle(GetProjectsByCustomerQuery request, CancellationToken cancellationToken)
    {
        var projects = await _projectService.GetByCustomerAsync(request.CustomerId, cancellationToken);
        return projects;
    }
}