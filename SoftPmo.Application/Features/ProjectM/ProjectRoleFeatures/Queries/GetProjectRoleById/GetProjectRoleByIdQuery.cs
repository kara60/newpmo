using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Queries.GetProjectRoleById;

public sealed record GetProjectRoleByIdQuery(
    string Id
) : IRequest<ProjectRole>;