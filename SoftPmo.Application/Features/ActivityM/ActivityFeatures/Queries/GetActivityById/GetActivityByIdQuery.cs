using MediatR;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetActivityById;

public sealed record GetActivityByIdQuery(
    string Id
) : IRequest<Domain.Entities.Activity.ActivityM>;