using MediatR;

namespace SoftPmo.Application.Features.LocationFeatures.Commands.DeleteLocation;

public sealed record DeleteLocationCommand(
    string Id
) : IRequest<DeleteLocationCommandResponse>;