using MediatR;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.DeleteActivity;

public sealed record DeleteActivityCommand(
    string Id
) : IRequest<DeleteActivityCommandResponse>;