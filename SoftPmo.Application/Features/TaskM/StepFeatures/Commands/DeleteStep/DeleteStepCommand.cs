using MediatR;

namespace SoftPmo.Application.Features.TaskM.StepFeatures.Commands.DeleteStep;

public sealed record DeleteStepCommand(
    string Id
) : IRequest<DeleteStepCommandResponse>;