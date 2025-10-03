using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.CreatePriority;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.DeletePriority;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.UpdatePriority;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Queries.GetAllPriorities;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Queries.GetPriorityById;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.TaskM;

public sealed class PrioritiesController : ApiController
{
    public PrioritiesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreatePriorityCommand request, CancellationToken cancellationToken)
    {
        CreatePriorityCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllPrioritiesQuery request, CancellationToken cancellationToken)
    {
        IList<Priority> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetPriorityByIdQuery(id);
        Priority response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdatePriorityCommand request, CancellationToken cancellationToken)
    {
        UpdatePriorityCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeletePriorityCommand(id);
        DeletePriorityCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}