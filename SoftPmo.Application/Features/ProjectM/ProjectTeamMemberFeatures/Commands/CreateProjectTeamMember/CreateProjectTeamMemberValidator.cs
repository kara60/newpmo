using FluentValidation;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.CreateProjectTeamMember;

public sealed class CreateProjectTeamMemberValidator : AbstractValidator<CreateProjectTeamMemberCommand>
{
    public CreateProjectTeamMemberValidator()
    {
        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage("Proje seçilmelidir.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Personel seçilmelidir.");

        RuleFor(x => x.ProjectRoleId)
            .NotEmpty().WithMessage("Proje rolü seçilmelidir.");

        RuleFor(x => x.JoinedDate)
            .NotEmpty().WithMessage("Katılım tarihi boş olamaz.")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("Katılım tarihi bugünden ileri olamaz.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}