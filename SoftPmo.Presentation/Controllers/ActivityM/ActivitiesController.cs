using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.ApproveActivity;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.CreateActivity;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.DeleteActivity;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.UpdateActivity;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetActivitiesByTask;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetActivitiesByUser;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetActivityById;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetAllActivities;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetPendingApprovals;
using SoftPmo.Domain.Entities.Activity;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.ActivityM;

public sealed class ActivitiesController : ApiController
{
    public ActivitiesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateActivityCommand request, CancellationToken cancellationToken)
    {
        CreateActivityCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllActivitiesQuery request, CancellationToken cancellationToken)
    {
        IList<Domain.Entities.Activity.ActivityM> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetActivityByIdQuery(id);
        Domain.Entities.Activity.ActivityM response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetByUser(
        string userId,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        CancellationToken cancellationToken = default)
    {
        var query = new GetActivitiesByUserQuery(userId, startDate, endDate);
        IList<Domain.Entities.Activity.ActivityM> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("Task/{taskId}")]
    public async Task<IActionResult> GetByTask(string taskId, CancellationToken cancellationToken)
    {
        var query = new GetActivitiesByTaskQuery(taskId);
        IList<Domain.Entities.Activity.ActivityM> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("PendingApprovals")]
    public async Task<IActionResult> GetPendingApprovals([FromQuery] string? managerId = null, CancellationToken cancellationToken = default)
    {
        var query = new GetPendingApprovalsQuery(managerId);
        IList<Domain.Entities.Activity.ActivityM> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("[action]")]
    public async Task<IActionResult> Update(UpdateActivityCommand request, CancellationToken cancellationToken)
    {
        UpdateActivityCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpPut("{id}/Approve")]
    public async Task<IActionResult> Approve(string id, [FromBody] ApproveActivityRequest request, CancellationToken cancellationToken)
    {
        var command = new ApproveActivityCommand(id, request.ApprovedByUserId, request.IsApproved, request.ApprovalNote);
        ApproveActivityCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteActivityCommand(id);
        DeleteActivityCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}

// Helper Request Model
public record ApproveActivityRequest(
    string ApprovedByUserId,
    bool IsApproved,
    string? ApprovalNote
);