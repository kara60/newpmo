using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.CreateCustomerLocation;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.DeleteCustomerLocation;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.UpdateCustomerLocation;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetAllCustomerLocations;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetCustomerLocationById;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetLocationsByCustomer;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.CustomerM;

public sealed class CustomerLocationsController : ApiController
{
    public CustomerLocationsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCustomerLocationCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerLocationCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerLocationsQuery request, CancellationToken cancellationToken)
    {
        IList<CustomerLocation> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetCustomerLocationByIdQuery(id);
        CustomerLocation response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("Customer/{customerId}")]
    public async Task<IActionResult> GetByCustomer(string customerId, CancellationToken cancellationToken)
    {
        var query = new GetLocationsByCustomerQuery(customerId);
        IList<CustomerLocation> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateCustomerLocationCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomerLocationCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteCustomerLocationCommand(id);
        DeleteCustomerLocationCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}