using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Queries.GetAllProjectTypes;

public sealed record GetAllProjectTypesQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string? Category = null
) : IRequest<IList<ProjectType>>;