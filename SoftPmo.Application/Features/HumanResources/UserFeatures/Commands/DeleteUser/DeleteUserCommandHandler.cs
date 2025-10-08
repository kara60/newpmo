using MediatR;
using SoftPmo.Application.Services.HumanResources;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.DeleteUser;

public sealed class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandResponse>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteUserCommandResponse();
    }
}