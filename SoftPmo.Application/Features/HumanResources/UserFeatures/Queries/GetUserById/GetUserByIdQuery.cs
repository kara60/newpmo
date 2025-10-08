using MediatR;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetUserById;

public sealed record GetUserByIdQuery(
    string Id
) : IRequest<User>;