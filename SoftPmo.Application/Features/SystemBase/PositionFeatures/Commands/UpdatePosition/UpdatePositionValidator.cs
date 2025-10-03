using FluentValidation;

namespace SoftPmo.Application.Features.SystemBase.PositionFeatures.Commands.UpdatePosition;

public sealed class UpdatePositionValidator : AbstractValidator<UpdatePositionCommand>
{
    public UpdatePositionValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Pozisyon adı boş olamaz.")
            .MinimumLength(2).WithMessage("Pozisyon adı en az 2 karakter olmalıdır.")
            .MaximumLength(200).WithMessage("Pozisyon adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.DepartmentId)
            .NotEmpty().WithMessage("Departman seçilmelidir.");

        RuleFor(x => x.PositionLevelId)
            .NotEmpty().WithMessage("Pozisyon seviyesi seçilmelidir.");

        RuleFor(x => x.BillingMultiplier)
            .GreaterThan(0).WithMessage("Faturalama çarpanı 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(10).WithMessage("Faturalama çarpanı en fazla 10 olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}