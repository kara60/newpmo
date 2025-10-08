using MediatR;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Commands.UpdateStep;

public sealed record UpdateStepCommand(
    string Id,
    string Name,
    int SortOrder,
    string? Description,
    bool IsActive
) : IRequest<UpdateStepCommandResponse>;