using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Queries.GetProjectStatusById;

public sealed record GetProjectStatusByIdQuery(
    string Id
) : IRequest<ProjectStatus>;