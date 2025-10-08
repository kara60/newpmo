using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.CreateProjectTeamMember;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.DeleteProjectTeamMember;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.UpdateProjectTeamMember;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetAllProjectTeamMembers;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetProjectTeamMemberById;
using SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Queries.GetTeamMembersByProject;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Presentation.Abstraction;
namespace SoftPmo.Presentation.Controllers.ProjectM;
public sealed class ProjectTeamMembersController : ApiController
{
    public ProjectTeamMembersController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProjectTeamMemberCommand request, CancellationToken cancellationToken)
    {
        CreateProjectTeamMemberCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProjectTeamMembersQuery request, CancellationToken cancellationToken)
    {
        IList<ProjectTeamMember> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetProjectTeamMemberByIdQuery(id);
        ProjectTeamMember response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("Project/{projectId}")]
    public async Task<IActionResult> GetByProject(string projectId, CancellationToken cancellationToken)
    {
        var query = new GetTeamMembersByProjectQuery(projectId);
        IList<ProjectTeamMember> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateProjectTeamMemberCommand request, CancellationToken cancellationToken)
    {
        UpdateProjectTeamMemberCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteProjectTeamMemberCommand(id);
        DeleteProjectTeamMemberCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}