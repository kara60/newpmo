using FluentValidation;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.CreateSystemParameter;

public sealed class CreateSystemParameterValidator : AbstractValidator<CreateSystemParameterCommand>
{
    public CreateSystemParameterValidator()
    {
        RuleFor(x => x.ParameterKey)
            .NotEmpty().WithMessage("Parametre anahtarı boş olamaz.")
            .MinimumLength(2).WithMessage("Parametre anahtarı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Parametre anahtarı en fazla 100 karakter olabilir.")
            .Matches("^[A-Z_][A-Z0-9_]*$").WithMessage("Parametre anahtarı sadece büyük harf, rakam ve alt çizgi içerebilir (ör: DAILY_WORK_HOURS)");

        RuleFor(x => x.ParameterValue)
            .NotEmpty().WithMessage("Parametre değeri boş olamaz.")
            .MaximumLength(500).WithMessage("Parametre değeri en fazla 500 karakter olabilir.");

        RuleFor(x => x.Category)
            .MaximumLength(100).WithMessage("Kategori en fazla 100 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Category));

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}