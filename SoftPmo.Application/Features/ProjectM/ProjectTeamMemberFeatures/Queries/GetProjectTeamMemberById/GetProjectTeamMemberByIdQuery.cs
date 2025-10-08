using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetProjectTeamMemberById;

public sealed record GetProjectTeamMemberByIdQuery(
    string Id
) : IRequest<ProjectTeamMember>;