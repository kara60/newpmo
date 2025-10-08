using MediatR;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetActivitiesByUser;

public sealed record GetActivitiesByUserQuery(
    string UserId,
    DateTime? StartDate = null,
    DateTime? EndDate = null
) : IRequest<IList<Domain.Entities.Activity.ActivityM>>;