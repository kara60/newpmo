using MediatR;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetPendingApprovals;

public sealed record GetPendingApprovalsQuery(
    string? ManagerId = null
) : IRequest<IList<Domain.Entities.Activity.ActivityM>>;