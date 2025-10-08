using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.CreateCustomer;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.DeleteCustomer;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.UpdateCustomer;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetAllCustomers;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetCustomerById;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetCustomerWithDetails;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.CustomerM;

public sealed class CustomersController : ApiController
{
    public CustomersController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        CreateCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        IList<Domain.Entities.Customer.CustomerM> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetCustomerByIdQuery(id);
        Domain.Entities.Customer.CustomerM response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}/Details")]
    public async Task<IActionResult> GetWithDetails(string id, CancellationToken cancellationToken)
    {
        var query = new GetCustomerWithDetailsQuery(id);
        Domain.Entities.Customer.CustomerM response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        UpdateCustomerCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteCustomerCommand(id);
        DeleteCustomerCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}