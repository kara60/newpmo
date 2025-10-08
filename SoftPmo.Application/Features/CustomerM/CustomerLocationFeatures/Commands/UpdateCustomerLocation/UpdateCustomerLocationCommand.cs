using MediatR;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.UpdateCustomerLocation;

public sealed record UpdateCustomerLocationCommand(
    string Id,
    string CustomerId,
    string LocationName,
    string? Address,
    string? Phone,
    string? LocationType,
    bool IsDefault,
    string? Description,
    bool IsActive
) : IRequest<UpdateCustomerLocationCommandResponse>;