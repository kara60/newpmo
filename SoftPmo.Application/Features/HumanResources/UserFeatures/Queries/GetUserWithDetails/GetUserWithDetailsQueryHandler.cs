using MediatR;
using SoftPmo.Application.Services.HumanResources;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetUserWithDetails;

public sealed class GetUserWithDetailsQueryHandler : IRequestHandler<GetUserWithDetailsQuery, User>
{
    private readonly IUserService _userService;

    public GetUserWithDetailsQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<User> Handle(GetUserWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var user = await _userService.GetWithDetailsAsync(request.Id, cancellationToken);
        return user;
    }
}