using MediatR;
using SoftPmo.Application.Services.HumanResources;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.UpdateUser;

public sealed class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
{
    private readonly IUserService _userService;

    public UpdateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateAsync(request, cancellationToken);
        return new UpdateUserCommandResponse();
    }
}