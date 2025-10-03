using FluentValidation;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.CreateLocationType;

public sealed class CreateLocationTypeValidator : AbstractValidator<CreateLocationTypeCommand>
{
    public CreateLocationTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Lokasyon tipi adı boş olamaz.")
            .MinimumLength(2).WithMessage("Lokasyon tipi adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Lokasyon tipi adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}