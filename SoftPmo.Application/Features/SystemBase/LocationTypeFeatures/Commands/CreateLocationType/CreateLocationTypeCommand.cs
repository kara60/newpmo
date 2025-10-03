using MediatR;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.CreateLocationType;

public sealed record CreateLocationTypeCommand(
    string Name,
    string Description
) : IRequest<CreateLocationTypeCommandResponse>;