using MediatR;
using SoftPmo.Application.Services.NotificationM;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.MarkAsRead;

public sealed class MarkAsReadCommandHandler : IRequestHandler<MarkAsReadCommand, MarkAsReadCommandResponse>
{
    private readonly INotificationService _notificationService;

    public MarkAsReadCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<MarkAsReadCommandResponse> Handle(MarkAsReadCommand request, CancellationToken cancellationToken)
    {
        await _notificationService.MarkAsReadAsync(request.Id, cancellationToken);
        return new MarkAsReadCommandResponse();
    }
}