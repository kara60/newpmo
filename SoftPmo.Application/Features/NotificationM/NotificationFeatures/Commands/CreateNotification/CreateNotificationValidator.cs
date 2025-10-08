using FluentValidation;

namespace SoftPmo.Application.Features.NotificationM.NotificationFeatures.Commands.CreateNotification;

public sealed class CreateNotificationValidator : AbstractValidator<CreateNotificationCommand>
{
    public CreateNotificationValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Kullanıcı seçilmelidir.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Başlık boş olamaz.")
            .MaximumLength(200).WithMessage("Başlık en fazla 200 karakter olabilir.");

        RuleFor(x => x.Message)
            .NotEmpty().WithMessage("Mesaj boş olamaz.")
            .MaximumLength(1000).WithMessage("Mesaj en fazla 1000 karakter olabilir.");

        RuleFor(x => x.NotificationType)
            .NotEmpty().WithMessage("Bildirim tipi boş olamaz.")
            .MaximumLength(50).WithMessage("Bildirim tipi en fazla 50 karakter olabilir.");

        RuleFor(x => x.RelatedEntityType)
            .MaximumLength(50).WithMessage("İlişkili entity tipi en fazla 50 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.RelatedEntityType));
    }
}