using FluentValidation;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.CreateProjectStatus;

public sealed class CreateProjectStatusValidator : AbstractValidator<CreateProjectStatusCommand>
{
    public CreateProjectStatusValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Proje durumu adı boş olamaz.")
            .MinimumLength(2).WithMessage("Proje durumu adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Proje durumu adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.StatusType)
            .NotEmpty().WithMessage("Durum tipi seçilmelidir.")
            .Must(BeValidStatusType).WithMessage("Geçerli durum tipleri: Planning, Active, OnHold, Completed, Cancelled");

        RuleFor(x => x.SortOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Sıra numarası 0 veya daha büyük olmalıdır.");

        RuleFor(x => x.ColorCode)
            .MaximumLength(50).WithMessage("Renk kodu en fazla 50 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.ColorCode));

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }

    private bool BeValidStatusType(string statusType)
    {
        var validTypes = new[] { "Planning", "Active", "OnHold", "Completed", "Cancelled" };
        return validTypes.Contains(statusType);
    }
}