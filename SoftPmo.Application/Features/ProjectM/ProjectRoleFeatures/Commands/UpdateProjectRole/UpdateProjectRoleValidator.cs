using FluentValidation;

namespace SoftPmo.Application.Features.ProjectM.ProjectRoleFeatures.Commands.UpdateProjectRole;

public sealed class UpdateProjectRoleValidator : AbstractValidator<UpdateProjectRoleCommand>
{
    public UpdateProjectRoleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Proje rolü adı boş olamaz.")
            .MinimumLength(2).WithMessage("Proje rolü adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Proje rolü adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}