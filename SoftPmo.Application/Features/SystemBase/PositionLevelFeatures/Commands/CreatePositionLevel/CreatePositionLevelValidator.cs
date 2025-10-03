using FluentValidation;

namespace SoftPmo.Application.Features.SystemBase.PositionLevelFeatures.Commands.CreatePositionLevel;

public sealed class CreatePositionLevelValidator : AbstractValidator<CreatePositionLevelCommand>
{
    public CreatePositionLevelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Pozisyon seviyesi adı boş olamaz.")
            .MinimumLength(2).WithMessage("Pozisyon seviyesi adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Pozisyon seviyesi adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.DefaultBillingMultiplier)
            .GreaterThan(0).WithMessage("Varsayılan faturalama çarpanı 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(10).WithMessage("Varsayılan faturalama çarpanı en fazla 10 olabilir.");

        RuleFor(x => x.SortOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Sıra numarası 0 veya daha büyük olmalıdır.");

        RuleFor(x => x.ColorCode)
            .MaximumLength(50).WithMessage("Renk kodu en fazla 50 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.ColorCode));

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}