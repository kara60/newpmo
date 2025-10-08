using FluentValidation;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateParameterValue;

public sealed class UpdateParameterValueValidator : AbstractValidator<UpdateParameterValueCommand>
{
    public UpdateParameterValueValidator()
    {
        RuleFor(x => x.ParameterKey)
            .NotEmpty().WithMessage("Parametre anahtarı boş olamaz.");

        RuleFor(x => x.ParameterValue)
            .NotEmpty().WithMessage("Parametre değeri boş olamaz.")
            .MaximumLength(500).WithMessage("Parametre değeri en fazla 500 karakter olabilir.");
    }
}