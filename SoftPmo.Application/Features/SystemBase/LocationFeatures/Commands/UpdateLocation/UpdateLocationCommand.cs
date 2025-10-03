using MediatR;

namespace SoftPmo.Application.Features.SystemBase.LocationFeatures.Commands.UpdateLocation;

public sealed record UpdateLocationCommand(
    string Id,
    string Name,
    string LocationTypeId,
    string Address,
    string Phone,
    string Description,
    bool IsActive
) : IRequest<UpdateLocationCommandResponse>;