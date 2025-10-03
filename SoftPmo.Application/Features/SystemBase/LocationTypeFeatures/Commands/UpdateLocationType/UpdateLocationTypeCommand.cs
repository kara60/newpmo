using MediatR;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.UpdateLocationType;

public sealed record UpdateLocationTypeCommand(
    string Id,
    string Name,
    string Description,
    bool IsActive
) : IRequest<UpdateLocationTypeCommandResponse>;