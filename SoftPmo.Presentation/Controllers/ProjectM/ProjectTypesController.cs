using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.CreateProjectType;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.DeleteProjectType;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.UpdateProjectType;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Queries.GetAllProjectTypes;
using SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Queries.GetProjectTypeById;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.ProjectM;

public sealed class ProjectTypesController : ApiController
{
    public ProjectTypesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProjectTypeCommand request, CancellationToken cancellationToken)
    {
        CreateProjectTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProjectTypesQuery request, CancellationToken cancellationToken)
    {
        IList<ProjectType> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetProjectTypeByIdQuery(id);
        ProjectType response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateProjectTypeCommand request, CancellationToken cancellationToken)
    {
        UpdateProjectTypeCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteProjectTypeCommand(id);
        DeleteProjectTypeCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}