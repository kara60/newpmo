using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.CreateProject;

public sealed record CreateProjectCommand(
    string Name,
    string CustomerId,
    string ProjectTypeId,
    string ProjectManagerId,
    DateTime StartDate,
    DateTime? PlannedEndDate,
    int? EstimatedDurationDays,
    string ProjectStatusId,
    string? PriorityId,
    string? Description
) : IRequest<CreateProjectCommandResponse>;