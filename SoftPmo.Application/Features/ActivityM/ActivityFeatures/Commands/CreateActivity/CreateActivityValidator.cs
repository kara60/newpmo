using FluentValidation;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.CreateActivity;

public sealed class CreateActivityValidator : AbstractValidator<CreateActivityCommand>
{
    public CreateActivityValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Personel seçilmelidir.");

        RuleFor(x => x.TaskId)
            .NotEmpty().WithMessage("İş seçilmelidir.");

        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("Başlangıç saati boş olamaz.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("Bitiş saati boş olamaz.")
            .GreaterThan(x => x.StartTime).WithMessage("Bitiş saati başlangıç saatinden sonra olmalıdır.");

        RuleFor(x => x.DurationMinutes)
            .GreaterThan(0).WithMessage("Süre 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(1440).WithMessage("Süre 1 günden (1440 dk) fazla olamaz.");

        RuleFor(x => x.LocationId)
            .NotEmpty().WithMessage("Lokasyon seçilmelidir.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}