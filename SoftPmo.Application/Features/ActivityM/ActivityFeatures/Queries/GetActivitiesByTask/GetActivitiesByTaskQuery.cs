using MediatR;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetActivitiesByTask;

public sealed record GetActivitiesByTaskQuery(
    string TaskId
) : IRequest<IList<Domain.Entities.Activity.ActivityM>>;