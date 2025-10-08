using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.CreateTaskStatus;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.DeleteTaskStatus;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.UpdateTaskStatus;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetAllTaskStatuses;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetTaskStatusById;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetTaskStatusesByType;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.TaskM;

public sealed class TaskStatusesController : ApiController
{
    public TaskStatusesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        CreateTaskStatusCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTaskStatusesQuery request, CancellationToken cancellationToken)
    {
        IList<Domain.Entities.Task.TaskStatus> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetTaskStatusByIdQuery(id);
        Domain.Entities.Task.TaskStatus response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("ByType/{taskStatusTypeId}")]
    public async Task<IActionResult> GetByType(string taskStatusTypeId, CancellationToken cancellationToken)
    {
        var query = new GetTaskStatusesByTypeQuery(taskStatusTypeId);
        IList<Domain.Entities.Task.TaskStatus> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateTaskStatusCommand request, CancellationToken cancellationToken)
    {
        UpdateTaskStatusCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteTaskStatusCommand(id);
        DeleteTaskStatusCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}