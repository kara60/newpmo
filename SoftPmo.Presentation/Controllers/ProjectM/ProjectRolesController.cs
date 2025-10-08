using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.CreateProjectRole;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.DeleteProjectRole;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.UpdateProjectRole;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Queries.GetAllProjectRoles;
using SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Queries.GetProjectRoleById;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.ProjectM;

public sealed class ProjectRolesController : ApiController
{
    public ProjectRolesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProjectRoleCommand request, CancellationToken cancellationToken)
    {
        CreateProjectRoleCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProjectRolesQuery request, CancellationToken cancellationToken)
    {
        IList<ProjectRole> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetProjectRoleByIdQuery(id);
        ProjectRole response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateProjectRoleCommand request, CancellationToken cancellationToken)
    {
        UpdateProjectRoleCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteProjectRoleCommand(id);
        DeleteProjectRoleCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}