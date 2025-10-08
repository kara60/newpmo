using FluentValidation;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.UpdateProjectType;

public sealed class UpdateProjectTypeValidator : AbstractValidator<UpdateProjectTypeCommand>
{
    public UpdateProjectTypeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Proje tipi adı boş olamaz.")
            .MinimumLength(2).WithMessage("Proje tipi adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Proje tipi adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Category)
            .MaximumLength(100).WithMessage("Kategori en fazla 100 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Category));

        RuleFor(x => x.DefaultDurationDays)
            .GreaterThan(0).WithMessage("Varsayılan süre 0'dan büyük olmalıdır.")
            .When(x => x.DefaultDurationDays.HasValue);

        RuleFor(x => x.ColorCode)
            .MaximumLength(50).WithMessage("Renk kodu en fazla 50 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.ColorCode));

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}