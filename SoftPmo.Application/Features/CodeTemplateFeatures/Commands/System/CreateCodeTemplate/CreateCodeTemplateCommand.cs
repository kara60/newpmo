using MediatR;

namespace SoftPmo.Application.Features.CodeTemplateFeatures.Commands.System.CreateCodeTemplate;

public sealed record CreateCodeTemplateCommand(
    string EntityType,
    string CodeFormat,
    string Prefix,
    bool UserYear,
    int SequenceLength,
    int StartingNumber,
    int CurrentNumber) : IRequest<CreateCodeTemplateCommandResponse>;
