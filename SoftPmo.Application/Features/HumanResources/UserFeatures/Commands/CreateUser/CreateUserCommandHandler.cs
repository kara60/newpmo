using MediatR;
using SoftPmo.Application.Services.HumanResources;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.CreateUser;

public sealed class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var response = await _userService.CreateAsync(request, cancellationToken);
        return response;
    }
}