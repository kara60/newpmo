using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetAllProjectTeamMembers;

public sealed record GetAllProjectTeamMembersQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string? ProjectId = null,
    string? UserId = null
) : IRequest<IList<ProjectTeamMember>>;