using FluentValidation;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Commands.UpdateStep;

public sealed class UpdateStepValidator : AbstractValidator<UpdateStepCommand>
{
    public UpdateStepValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ID boş olamaz.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("İş adımı adı boş olamaz.")
            .MinimumLength(2).WithMessage("İş adımı adı en az 2 karakter olmalıdır.")
            .MaximumLength(100).WithMessage("İş adımı adı en fazla 100 karakter olabilir.");

        RuleFor(x => x.SortOrder)
            .GreaterThanOrEqualTo(0).WithMessage("Sıra numarası 0 veya daha büyük olmalıdır.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.")
            .When(x => !string.IsNullOrEmpty(x.Description));
    }
}