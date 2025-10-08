using MediatR;
using SoftPmo.Application.Services.NotificationM;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.CreateNotification;

public sealed class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, CreateNotificationCommandResponse>
{
    private readonly INotificationService _notificationService;

    public CreateNotificationCommandHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<CreateNotificationCommandResponse> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
    {
        var response = await _notificationService.CreateAsync(request, cancellationToken);
        return response;
    }
}