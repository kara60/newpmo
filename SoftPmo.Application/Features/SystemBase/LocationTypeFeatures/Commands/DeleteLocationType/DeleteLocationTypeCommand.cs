using MediatR;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.DeleteLocationType;

public sealed record DeleteLocationTypeCommand(
    string Id
) : IRequest<DeleteLocationTypeCommandResponse>;