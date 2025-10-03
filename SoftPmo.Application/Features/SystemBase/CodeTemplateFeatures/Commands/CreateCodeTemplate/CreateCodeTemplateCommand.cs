using MediatR;

namespace SoftPmo.Application.Features.SystemBase.CodeTemplateFeatures.Commands.CreateCodeTemplate;

public sealed record CreateCodeTemplateCommand(
    string EntityType,
    string CodeFormat,
    string Prefix,
    bool UseYear,
    int SequenceLength,
    int StartingNumber,
    int CurrentNumber) : IRequest<CreateCodeTemplateCommandResponse>;
