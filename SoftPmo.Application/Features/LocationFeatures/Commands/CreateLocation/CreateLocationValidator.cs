using FluentValidation;

namespace SoftPmo.Application.Features.LocationFeatures.Commands.CreateLocation;

public sealed class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
{
    public CreateLocationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Lokasyon adı boş olamaz.")
            .MinimumLength(2).WithMessage("Lokasyon adı en az 2 karakter olmalıdır.")
            .MaximumLength(200).WithMessage("Lokasyon adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Adres boş olamaz.")
            .MaximumLength(500).WithMessage("Adres en fazla 500 karakter olabilir.");

        RuleFor(x => x.Phone)
            .MaximumLength(20).WithMessage("Telefon en fazla 20 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Phone));

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}