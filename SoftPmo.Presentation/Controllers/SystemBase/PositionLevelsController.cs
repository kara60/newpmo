using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Queries.GetPositionLevelById;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.CreatePositionLevel;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.DeletePositionLevel;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.UpdatePositionLevel;
using SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Queries.GetAllPositionLevels;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.SystemBase;

public sealed class PositionLevelsController : ApiController
{
    public PositionLevelsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreatePositionLevelCommand request, CancellationToken cancellationToken)
    {
        CreatePositionLevelCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllPositionLevelsQuery request, CancellationToken cancellationToken)
    {
        IList<PositionLevel> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetPositionLevelByIdQuery(id);
        PositionLevel response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdatePositionLevelCommand request, CancellationToken cancellationToken)
    {
        UpdatePositionLevelCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeletePositionLevelCommand(id);
        DeletePositionLevelCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}