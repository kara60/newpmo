using FluentValidation;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.CreateTask;

public sealed class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("İş başlığı boş olamaz.")
            .MinimumLength(3).WithMessage("İş başlığı en az 3 karakter olmalıdır.")
            .MaximumLength(300).WithMessage("İş başlığı en fazla 300 karakter olabilir.");

        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage("Müşteri seçilmelidir.");

        RuleFor(x => x.ProjectId)
            .NotEmpty().WithMessage("Proje seçilmelidir.");

        RuleFor(x => x.TaskTypeId)
            .NotEmpty().WithMessage("İş tipi seçilmelidir.");

        RuleFor(x => x.MainResponsibleUserId)
            .NotEmpty().WithMessage("Sorumlu personel seçilmelidir.");

        RuleFor(x => x.EstimatedDurationDays)
            .GreaterThan(0).WithMessage("Tahmini süre 0'dan büyük olmalıdır.");

        RuleFor(x => x.StartDate)
            .NotEmpty().WithMessage("Başlangıç tarihi boş olamaz.");

        RuleFor(x => x.DueDate)
            .NotEmpty().WithMessage("Termin tarihi boş olamaz.")
            .GreaterThan(x => x.StartDate).WithMessage("Termin tarihi başlangıç tarihinden sonra olmalıdır.");

        RuleFor(x => x.BillingMultiplier)
            .GreaterThan(0).WithMessage("Faturalama çarpanı 0'dan büyük olmalıdır.")
            .LessThanOrEqualTo(10).WithMessage("Faturalama çarpanı 10'dan küçük olmalıdır.");

        RuleFor(x => x.BillingDuration)
            .GreaterThan(0).WithMessage("Fatura süresi 0'dan büyük olmalıdır.");

        RuleFor(x => x.TaskStatusId)
            .NotEmpty().WithMessage("İş durumu seçilmelidir.");

        RuleFor(x => x.Description)
            .MaximumLength(2000).WithMessage("Açıklama en fazla 2000 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}