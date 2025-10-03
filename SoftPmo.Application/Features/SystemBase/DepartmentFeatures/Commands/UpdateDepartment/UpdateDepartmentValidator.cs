using FluentValidation;

namespace SoftPmo.Application.Features.SystemBase.DepartmentFeatures.Commands.UpdateDepartment;

public sealed class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommand>
{
    public UpdateDepartmentValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Departman adı boş olamaz.")
            .MinimumLength(2).WithMessage("Departman adı en az 2 karakter olmalıdır.")
            .MaximumLength(200).WithMessage("Departman adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(1000).WithMessage("Açıklama en fazla 1000 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));

        // Kendini parent olarak seçemez
        RuleFor(x => x)
            .Must(x => x.ParentDepartmentId != x.Id)
            .When(x => !string.IsNullOrEmpty(x.ParentDepartmentId))
            .WithMessage("Departman kendi üst departmanı olamaz.");
    }
}