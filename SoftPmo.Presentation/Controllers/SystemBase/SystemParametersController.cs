using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.CreateSystemParameter;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.DeleteSystemParameter;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateParameterValue;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateSystemParameter;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetAllSystemParameters;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetParameterByKey;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetSystemParameterById;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.SystemBase;

public sealed class SystemParametersController : ApiController
{
    public SystemParametersController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateSystemParameterCommand request, CancellationToken cancellationToken)
    {
        CreateSystemParameterCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllSystemParametersQuery request, CancellationToken cancellationToken)
    {
        IList<SystemParameter> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetSystemParameterByIdQuery(id);
        SystemParameter response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("ByKey/{parameterKey}")]
    public async Task<IActionResult> GetByKey(string parameterKey, CancellationToken cancellationToken)
    {
        var query = new GetParameterByKeyQuery(parameterKey);
        SystemParameter response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateSystemParameterCommand request, CancellationToken cancellationToken)
    {
        UpdateSystemParameterCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut("UpdateValue")]
    public async Task<IActionResult> UpdateValue(UpdateParameterValueCommand request, CancellationToken cancellationToken)
    {
        UpdateParameterValueCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteSystemParameterCommand(id);
        DeleteSystemParameterCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}