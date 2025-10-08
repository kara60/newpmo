using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.CreateNotification;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.DeleteNotification;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.MarkAsRead;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetAllNotifications;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetNotificationById;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetUnreadNotifications;
using SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetUserNotifications;
using SoftPmo.Domain.Entities.Notification;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.NotificationM;

public sealed class NotificationsController : ApiController
{
    public NotificationsController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        CreateNotificationCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] GetAllNotificationsQuery request, CancellationToken cancellationToken)
    {
        IList<Domain.Entities.Notification.NotificationM> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id, CancellationToken cancellationToken)
    {
        var query = new GetNotificationByIdQuery(id);
        Domain.Entities.Notification.NotificationM response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("User/{userId}")]
    public async Task<IActionResult> GetByUser(string userId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 20, CancellationToken cancellationToken = default)
    {
        var query = new GetUserNotificationsQuery(userId, pageNumber, pageSize);
        IList<Domain.Entities.Notification.NotificationM> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpGet("User/{userId}/Unread")]
    public async Task<IActionResult> GetUnreadByUser(string userId, CancellationToken cancellationToken)
    {
        var query = new GetUnreadNotificationsQuery(userId);
        IList<Domain.Entities.Notification.NotificationM> response = await _mediator.Send(query, cancellationToken);
        return Ok(response);
    }

    [HttpPut("{id}/MarkAsRead")]
    public async Task<IActionResult> MarkAsRead(string id, CancellationToken cancellationToken)
    {
        var command = new MarkAsReadCommand(id);
        MarkAsReadCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteNotificationCommand(id);
        DeleteNotificationCommandResponse response = await _mediator.Send(command, cancellationToken);
        return Ok(response);
    }
}