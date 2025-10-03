using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetPositionById;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetPositionsByDepartment;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.CreatePosition;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.DeletePosition;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.UpdatePosition;
using SoftPmo.Application.Features.SystemBase.PositionFeatures.Queries.GetAllPositions;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.SystemBase;

public sealed class PositionsController : ApiController
{
    public PositionsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreatePositionCommand request, CancellationToken cancellationToken)
    {
        CreatePositionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllPositionsQuery request, CancellationToken cancellationToken)
    {
        IList<Position> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetPositionByIdQuery(id);
        Position response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("ByDepartment/{departmentId}")]
    public async Task<IActionResult> GetByDepartment(string departmentId, CancellationToken cancellationToken)
    {
        var query = new GetPositionsByDepartmentQuery(departmentId);
        IList<Position> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdatePositionCommand request, CancellationToken cancellationToken)
    {
        UpdatePositionCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeletePositionCommand(id);
        DeletePositionCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}