using FluentValidation;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.CreateCustomerLocation;

public sealed class CreateCustomerLocationValidator : AbstractValidator<CreateCustomerLocationCommand>
{
    public CreateCustomerLocationValidator()
    {
        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Müşteri seçilmelidir.");

        RuleFor(x => x.LocationName)
            .NotEmpty().WithMessage("Lokasyon adı boş olamaz.")
            .MinimumLength(2).WithMessage("Lokasyon adı en az 2 karakter olmalıdır.")
            .MaximumLength(200).WithMessage("Lokasyon adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.Address)
            .MaximumLength(500).WithMessage("Adres en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Address));

        RuleFor(x => x.Phone)
            .MaximumLength(50).WithMessage("Telefon en fazla 50 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Phone));

        RuleFor(x => x.LocationType)
            .MaximumLength(100).WithMessage("Lokasyon tipi en fazla 100 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.LocationType));

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}