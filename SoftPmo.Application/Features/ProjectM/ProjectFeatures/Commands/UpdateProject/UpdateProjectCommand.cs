using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.UpdateProject;

public sealed record UpdateProjectCommand(
    string Id,
    string Name,
    string CustomerId,
    string ProjectTypeId,
    string ProjectManagerId,
    DateTime StartDate,
    DateTime? PlannedEndDate,
    DateTime? ActualEndDate,
    int? EstimatedDurationDays,
    string ProjectStatusId,
    string? PriorityId,
    string? Description,
    bool IsActive
) : IRequest<UpdateProjectCommandResponse>;