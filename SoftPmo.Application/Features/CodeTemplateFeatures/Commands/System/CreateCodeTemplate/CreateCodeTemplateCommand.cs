using MediatR;

namespace SoftPmo.Application.Features.CodeTemplateFeatures.Commands.System.CreateCodeTemplate;

public sealed record CreateCodeTemplateCommand(
    string EntityType,
    string CodeFormat,
    string Prefix,
    bool UseYear,
    int SequenceLength,
    int StartingNumber,
    int CurrentNumber) : IRequest<CreateCodeTemplateCommandResponse>;
