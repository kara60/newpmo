using FluentValidation;

namespace SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.UpdateTaskType;

public sealed class UpdateTaskTypeValidator : AbstractValidator<UpdateTaskTypeCommand>
{
    public UpdateTaskTypeValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İş tipi adı boş olamaz.")
            .MinimumLength(2).WithMessage("İş tipi adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("İş tipi adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.Category)
            .MaximumLength(100).WithMessage("Kategori en fazla 100 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Category));

        RuleFor(x => x.ColorCode)
            .MaximumLength(50).WithMessage("Renk kodu en fazla 50 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.ColorCode));

        RuleFor(x => x.IconCode)
            .MaximumLength(50).WithMessage("İkon kodu en fazla 50 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.IconCode));

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}