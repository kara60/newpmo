using MediatR;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetUserWithDetails;

public sealed record GetUserWithDetailsQuery(
    string Id
) : IRequest<User>;