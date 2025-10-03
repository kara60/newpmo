using FluentValidation;

namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.CreatePriority;

public sealed class CreatePriorityValidator : AbstractValidator<CreatePriorityCommand>
{
    public CreatePriorityValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Öncelik adı boş olamaz.")
            .MinimumLength(2).WithMessage("Öncelik adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("Öncelik adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.SortOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Sıra numarası 0 veya daha büyük olmalıdır.");

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