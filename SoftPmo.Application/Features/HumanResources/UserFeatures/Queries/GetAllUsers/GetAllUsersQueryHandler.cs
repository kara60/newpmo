using MediatR;
using SoftPmo.Application.Services.HumanResources;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetAllUsers;

public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IList<User>>
{
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IList<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetAllAsync(request, cancellationToken);
        return users;
    }
}