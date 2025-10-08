using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.CreateUser;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.DeleteUser;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.UpdateUser;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetAllUsers;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetUserById;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetUsersByDepartment;
using SoftPmo.Application.Features.HumanResources.UserFeatures.Queries.GetUserWithDetails;
using SoftPmo.Domain.Entities.HumanResources;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.HumanResources;

public sealed class UsersController : ApiController
{
    public UsersController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateUserCommand request, CancellationToken cancellationToken)
    {
        CreateUserCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        IList<User> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);
        User response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}/Details")]
    public async Task<IActionResult> GetWithDetails(string id, CancellationToken cancellationToken)
    {
        var query = new GetUserWithDetailsQuery(id);
        User response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("Department/{departmentId}")]
    public async Task<IActionResult> GetByDepartment(string departmentId, CancellationToken cancellationToken)
    {
        var query = new GetUsersByDepartmentQuery(departmentId);
        IList<User> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        UpdateUserCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(id);
        DeleteUserCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}