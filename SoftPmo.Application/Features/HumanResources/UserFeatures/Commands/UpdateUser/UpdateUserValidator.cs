using FluentValidation;

namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.UpdateUser;

public sealed class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("Ad boş olamaz.")
            .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Ad en fazla 100 karakter olabilir.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Soyad boş olamaz.")
            .MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Soyad en fazla 100 karakter olabilir.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş olamaz.")
            .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
            .MaximumLength(100).WithMessage("Email en fazla 100 karakter olabilir.");

        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Telefon boş olamaz.")
            .MaximumLength(50).WithMessage("Telefon en fazla 50 karakter olabilir.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("İşe başlama tarihi boş olamaz.")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("İşe başlama tarihi bugünden ileri olamaz.");

        RuleFor(x => x.DepartmentId)
            .NotEmpty().WithMessage("Departman seçilmelidir.");

        RuleFor(x => x.PositionId)
            .NotEmpty().WithMessage("Pozisyon seçilmelidir.");

        RuleFor(x => x.BillingMultiplier)
            .GreaterThan(0).WithMessage("Faturalama çarpanı 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(10).WithMessage("Faturalama çarpanı 10'dan küçük olmalıdır.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}