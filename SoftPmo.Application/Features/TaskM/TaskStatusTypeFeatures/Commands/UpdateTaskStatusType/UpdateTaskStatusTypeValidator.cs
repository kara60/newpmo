using FluentValidation;

namespace SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.UpdateTaskStatusType;

public sealed class UpdateTaskStatusTypeValidator : AbstractValidator<UpdateTaskStatusTypeCommand>
{
    public UpdateTaskStatusTypeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İş durumu tipi adı boş olamaz.")
            .MinimumLength(2).WithMessage("İş durumu tipi adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("İş durumu tipi adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.StatusCategory)
            .NotEmpty().WithMessage("Durum kategorisi boş olamaz.")
            .Must(BeValidCategory).WithMessage("Geçerli kategori: Waiting, Active, Completed, Cancelled");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }

    private bool BeValidCategory(string category)
    {
        var validCategories = new[] { "Waiting", "Active", "Completed", "Cancelled" };
        return validCategories.Contains(category);
    }
}