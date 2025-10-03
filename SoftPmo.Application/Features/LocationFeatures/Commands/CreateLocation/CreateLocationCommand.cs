using MediatR;

namespace SoftPmo.Application.Features.LocationFeatures.Commands.CreateLocation;

public sealed record CreateLocationCommand(
    string Name,
    string? LocationTypeId,
    string Address,
    string? Phone,
    string? Description
) : IRequest<CreateLocationCommandResponse>;
