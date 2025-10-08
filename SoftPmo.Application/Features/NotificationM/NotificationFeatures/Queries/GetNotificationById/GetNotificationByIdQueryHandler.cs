using MediatR;
using SoftPmo.Application.Services.NotificationM;
using SoftPmo.Domain.Entities.Notification;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Queries.GetNotificationById;

public sealed class GetNotificationByIdQueryHandler : IRequestHandler<GetNotificationByIdQuery, Domain.Entities.Notification.NotificationM>
{
    private readonly INotificationService _notificationService;

    public GetNotificationByIdQueryHandler(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    public async Task<Domain.Entities.Notification.NotificationM> Handle(GetNotificationByIdQuery request, CancellationToken cancellationToken)
    {
        var notification = await _notificationService.GetByIdAsync(request.Id, cancellationToken);
        return notification;
    }
}