using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Queries.GetLocationTypeById;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.CreateLocationType;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.DeleteLocationType;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.UpdateLocationType;
using SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Queries.GetAllLocationTypes;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.SystemBase;

public sealed class LocationTypesController : ApiController
{
    public LocationTypesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateLocationTypeCommand request, CancellationToken cancellationToken)
    {
        CreateLocationTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllLocationTypesQuery request, CancellationToken cancellationToken)
    {
        IList<LocationType> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetLocationTypeByIdQuery(id);
        LocationType response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateLocationTypeCommand request, CancellationToken cancellationToken)
    {
        UpdateLocationTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteLocationTypeCommand(id);
        DeleteLocationTypeCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}