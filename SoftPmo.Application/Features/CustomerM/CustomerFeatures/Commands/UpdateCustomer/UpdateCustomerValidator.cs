using FluentValidation;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.UpdateCustomer;

public sealed class UpdateCustomerValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Müşteri adı boş olamaz.")
            .MinimumLength(2).WithMessage("Müşteri adı en az 2 karakter olmalıdır.")
            .MaximumLength(200).WithMessage("Müşteri adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.TaxNumber)
            .MaximumLength(50).WithMessage("Vergi numarası en fazla 50 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.TaxNumber));

        RuleFor(x => x.Phone)
            .MaximumLength(50).WithMessage("Telefon en fazla 50 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Phone));

        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
            .MaximumLength(100).WithMessage("Email en fazla 100 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Email));

        RuleFor(x => x.Address)
            .MaximumLength(500).WithMessage("Adres en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Address));

        When(x => x.HasMaintenanceContract, () =>
        {
            RuleFor(x => x.MonthlyMaintenanceFee)
                .NotNull().WithMessage("Bakım sözleşmesi varsa aylık ücret girilmelidir.")
                .GreaterThan(0).WithMessage("Aylık ücret 0'dan büyük olmalıdır.");

            RuleFor(x => x.MaintenanceStartDate)
                .NotNull().WithMessage("Bakım sözleşmesi varsa başlangıç tarihi girilmelidir.");

            RuleFor(x => x.MaintenanceEndDate)
                .NotNull().WithMessage("Bakım sözleşmesi varsa bitiş tarihi girilmelidir.")
                .GreaterThan(x => x.MaintenanceStartDate).WithMessage("Bitiş tarihi başlangıç tarihinden sonra olmalıdır.");
        });

        RuleFor(x => x.PrimaryContactEmail)
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
            .When(x => !string.IsNullOrEmpty(x.PrimaryContactEmail));

        RuleFor(x => x.TechnicalContactEmail)
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
            .When(x => !string.IsNullOrEmpty(x.TechnicalContactEmail));

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}