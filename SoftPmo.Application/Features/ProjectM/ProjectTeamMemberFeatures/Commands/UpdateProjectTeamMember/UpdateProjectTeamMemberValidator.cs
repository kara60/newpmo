using FluentValidation;

namespace SoftPmo.Application.Features.ProjectM.ProjectTeamMemberFeatures.Commands.UpdateProjectTeamMember;

public sealed class UpdateProjectTeamMemberValidator : AbstractValidator<UpdateProjectTeamMemberCommand>
{
    public UpdateProjectTeamMemberValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage("Proje seçilmelidir.");

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("Personel seçilmelidir.");

        RuleFor(x => x.ProjectRoleId)
            .NotEmpty().WithMessage("Proje rolü seçilmelidir.");

        RuleFor(x => x.JoinedDate)
            .NotEmpty().WithMessage("Katılım tarihi boş olamaz.")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("Katılım tarihi bugünden ileri olamaz.");

        RuleFor(x => x.LeftDate)
            .GreaterThan(x => x.JoinedDate).WithMessage("Ayrılma tarihi katılım tarihinden sonra olmalıdır.")
            .When(x => x.LeftDate.HasValue);

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}