using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.CreateTaskType;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.DeleteTaskType;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.UpdateTaskType;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Queries.GetAllTaskTypes;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Queries.GetTaskTypeById;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.TaskM;

public sealed class TaskTypesController : ApiController
{
    public TaskTypesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateTaskTypeCommand request, CancellationToken cancellationToken)
    {
        CreateTaskTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllTaskTypesQuery request, CancellationToken cancellationToken)
    {
        IList<TaskType> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetTaskTypeByIdQuery(id);
        TaskType response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateTaskTypeCommand request, CancellationToken cancellationToken)
    {
        UpdateTaskTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteTaskTypeCommand(id);
        DeleteTaskTypeCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}