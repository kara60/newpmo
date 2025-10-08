using MediatR;
using SoftPmo.Application.Services.NotificationM;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.DeleteNotification;

public sealed class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, DeleteNotificationCommandResponse>
{
    private readonly INotificationService _notificationService;

    public DeleteNotificationCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<DeleteNotificationCommandResponse> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {
        await _notificationService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteNotificationCommandResponse();
    }
}