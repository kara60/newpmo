using MediatR;

namespace SoftPmo.Application.Features.SystemBase.LocationFeatures.Commands.DeleteLocation;

public sealed record DeleteLocationCommand(
    string Id
) : IRequest<DeleteLocationCommandResponse>;