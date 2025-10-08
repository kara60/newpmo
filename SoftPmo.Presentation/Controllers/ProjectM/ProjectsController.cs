using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.CreateProject;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.DeleteProject;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.UpdateProject;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetAllProjects;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetProjectById;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetProjectsByCustomer;
using SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetProjectWithDetails;
using SoftPmo.Domain.Entities.Project;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.ProjectM;

public sealed class ProjectsController : ApiController
{
    public ProjectsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        CreateProjectCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        IList<Domain.Entities.Project.ProjectM> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetProjectByIdQuery(id);
        Domain.Entities.Project.ProjectM response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}/Details")]
    public async Task<IActionResult> GetWithDetails(string id, CancellationToken cancellationToken)
    {
        var query = new GetProjectWithDetailsQuery(id);
        Domain.Entities.Project.ProjectM response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("Customer/{customerId}")]
    public async Task<IActionResult> GetByCustomer(string customerId, CancellationToken cancellationToken)
    {
        var query = new GetProjectsByCustomerQuery(customerId);
        IList<Domain.Entities.Project.ProjectM> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        UpdateProjectCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteProjectCommand(id);
        DeleteProjectCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}