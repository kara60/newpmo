using FluentValidation;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.CreateProject;

public sealed class CreateProjectValidator : AbstractValidator<CreateProjectCommand>
{
    public CreateProjectValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Proje adı boş olamaz.")
            .MinimumLength(2).WithMessage("Proje adı en az 2 karakter olmalıdır.")
            .MaximumLength(200).WithMessage("Proje adı en fazla 200 karakter olabilir.");

        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Müşteri seçilmelidir.");

        RuleFor(x => x.ProjectTypeId)
            .NotEmpty().WithMessage("Proje tipi seçilmelidir.");

        RuleFor(x => x.ProjectManagerId)
            .NotEmpty().WithMessage("Proje müdürü seçilmelidir.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Başlangıç tarihi boş olamaz.");

        RuleFor(x => x.PlannedEndDate)
            .GreaterThan(x => x.StartDate).WithMessage("Bitiş tarihi başlangıç tarihinden sonra olmalıdır.")
            .When(x => x.PlannedEndDate.HasValue);

        RuleFor(x => x.EstimatedDurationDays)
            .GreaterThan(0).WithMessage("Tahmini süre 0'dan büyük olmalıdır.")
            .When(x => x.EstimatedDurationDays.HasValue);

        RuleFor(x => x.ProjectStatusId)
            .NotEmpty().WithMessage("Proje durumu seçilmelidir.");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Açıklama en fazla 2000 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}