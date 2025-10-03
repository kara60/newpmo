using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.LocationFeatures.Commands.CreateLocation;
using SoftPmo.Application.Features.LocationFeatures.Commands.DeleteLocation;
using SoftPmo.Application.Features.LocationFeatures.Commands.UpdateLocation;
using SoftPmo.Application.Features.LocationFeatures.Queries.GetAllLocations;
using SoftPmo.Application.Features.LocationFeatures.Queries.GetLocationById;
using SoftPmo.Domain.Entities.System;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.System;

public sealed class LocationsController : ApiController
{
    public LocationsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        CreateLocationCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllLocationsQuery request, CancellationToken cancellationToken)
    {
        IList<Location> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetLocationByIdQuery(id);
        Location response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateLocationCommand request, CancellationToken cancellationToken)
    {
        UpdateLocationCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteLocationCommand(id);
        DeleteLocationCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}