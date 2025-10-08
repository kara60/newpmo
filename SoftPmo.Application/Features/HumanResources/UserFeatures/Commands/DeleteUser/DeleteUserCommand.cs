using MediatR;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.DeleteUser;

public sealed record DeleteUserCommand(
    string Id
) : IRequest<DeleteUserCommandResponse>;