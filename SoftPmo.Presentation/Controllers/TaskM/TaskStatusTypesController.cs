using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.CreateTaskStatusType;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.DeleteTaskStatusType;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.UpdateTaskStatusType;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Queries.GetAllTaskStatusTypes;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Queries.GetTaskStatusTypeById;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.TaskM;

public sealed class TaskStatusTypesController : ApiController
{
    public TaskStatusTypesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateTaskStatusTypeCommand request, CancellationToken cancellationToken)
    {
        CreateTaskStatusTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTaskStatusTypesQuery request, CancellationToken cancellationToken)
    {
        IList<TaskStatusType> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetTaskStatusTypeByIdQuery(id);
        TaskStatusType response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateTaskStatusTypeCommand request, CancellationToken cancellationToken)
    {
        UpdateTaskStatusTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteTaskStatusTypeCommand(id);
        DeleteTaskStatusTypeCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}