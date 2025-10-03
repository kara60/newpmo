using FluentValidation;

namespace SoftPmo.Application.Features.CodeTemplateFeatures.Commands.System.CreateCodeTemplate;

public sealed class CreateCodeTemplateValidator : AbstractValidator<CreateCodeTemplateCommand>
{
    public CreateCodeTemplateValidator()
    {
        RuleFor(p => p.EntityType).NotEmpty().WithMessage("Ekran türü boş olamaz.");
        RuleFor(p => p.Prefix).NotEmpty().WithMessage("Kod yapısı boş olamaz.");
        RuleFor(p => p.Prefix).MinimumLength(1).WithMessage("Prefix en az 1 karakter olmalıdır.");
        RuleFor(p => p.CodeFormat).NotEmpty().WithMessage("Kod yapısı boş olamaz.");
        RuleFor(p => p.SequenceLength).GreaterThan(3).WithMessage("Uzunluk 3 den büyük olmalıdır.");
    }
}