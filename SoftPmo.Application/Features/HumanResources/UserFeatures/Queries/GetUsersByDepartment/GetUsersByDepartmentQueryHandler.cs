using MediatR;
using SoftPmo.Application.Services.HumanResources;
using SoftPmo.Domain.Entities.HumanResources;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetUsersByDepartment;

public sealed class GetUsersByDepartmentQueryHandler : IRequestHandler<GetUsersByDepartmentQuery, IList<User>>
{
    private readonly IUserService _userService;

    public GetUsersByDepartmentQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IList<User>> Handle(GetUsersByDepartmentQuery request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetByDepartmentAsync(request.DepartmentId, cancellationToken);
        return users;
    }
}