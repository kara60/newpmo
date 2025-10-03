using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Queries.GetDepartmentById;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Queries.GetDepartmentHierarchy;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.CreateDepartment;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.DeleteDepartment;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.UpdateDepartment;
using SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Queries.GetAllDepartments;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.SystemBase;

public sealed class DepartmentsController : ApiController
{
    public DepartmentsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateDepartmentCommand request, CancellationToken cancellationToken)
    {
        CreateDepartmentCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllDepartmentsQuery request, CancellationToken cancellationToken)
    {
        IList<Department> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetDepartmentByIdQuery(id);
        Department response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<IActionResult> GetHierarchy(CancellationToken cancellationToken)
    {
        var query = new GetDepartmentHierarchyQuery();
        IList<Department> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateDepartmentCommand request, CancellationToken cancellationToken)
    {
        UpdateDepartmentCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteDepartmentCommand(id);
        DeleteDepartmentCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}