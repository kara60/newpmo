using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetTeamMembersByProject;

public sealed record GetTeamMembersByProjectQuery(
    string ProjectId
) : IRequest<IList<ProjectTeamMember>>;