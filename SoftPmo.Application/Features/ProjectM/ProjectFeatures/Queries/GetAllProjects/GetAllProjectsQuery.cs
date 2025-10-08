using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetAllProjects;

public sealed record GetAllProjectsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string? CustomerId = null,
    string? ProjectManagerId = null,
    string? ProjectStatusId = null
) : IRequest<IList<Domain.Entities.Project.ProjectM>>;