using MediatR;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Commands.CreateStep;

public sealed record CreateStepCommand(
    string Name,
    int SortOrder,
    string? Description
) : IRequest<CreateStepCommandResponse>;