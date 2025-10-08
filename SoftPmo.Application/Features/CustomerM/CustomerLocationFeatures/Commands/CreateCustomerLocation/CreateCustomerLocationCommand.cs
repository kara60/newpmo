using MediatR;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.CreateCustomerLocation;

public sealed record CreateCustomerLocationCommand(
    string CustomerId,
    string LocationName,
    string? Address,
    string? Phone,
    string? LocationType,
    bool IsDefault,
    string? Description
) : IRequest<CreateCustomerLocationCommandResponse>;