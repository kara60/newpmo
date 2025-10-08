using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.TaskM.StepFeatures.Commands.CreateStep;
using SoftPmo.Application.Features.TaskM.StepFeatures.Commands.DeleteStep;
using SoftPmo.Application.Features.TaskM.StepFeatures.Commands.UpdateStep;
using SoftPmo.Application.Features.TaskM.StepFeatures.Queries.GetAllSteps;
using SoftPmo.Application.Features.TaskM.StepFeatures.Queries.GetStepById;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.TaskM;

public sealed class StepsController : ApiController
{
    public StepsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateStepCommand request, CancellationToken cancellationToken)
    {
        CreateStepCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllStepsQuery request, CancellationToken cancellationToken)
    {
        IList<Step> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetStepByIdQuery(id);
        Step response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateStepCommand request, CancellationToken cancellationToken)
    {
        UpdateStepCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteStepCommand(id);
        DeleteStepCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}