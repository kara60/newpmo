using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.CreateProjectStatus;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.DeleteProjectStatus;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.UpdateProjectStatus;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Queries.GetAllProjectStatuses;
using SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Queries.GetProjectStatusById;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.ProjectM;

public sealed class ProjectStatusesController : ApiController
{
    public ProjectStatusesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProjectStatusCommand request, CancellationToken cancellationToken)
    {
        CreateProjectStatusCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProjectStatusesQuery request, CancellationToken cancellationToken)
    {
        IList<ProjectStatus> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetProjectStatusByIdQuery(id);
        ProjectStatus response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateProjectStatusCommand request, CancellationToken cancellationToken)
    {
        UpdateProjectStatusCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteProjectStatusCommand(id);
        DeleteProjectStatusCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}