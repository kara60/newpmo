using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.UpdateTask;

public sealed record UpdateTaskCommand(
    string Id,
    string Title,
    string CustomerId,
    string ProjectId,
    string TaskTypeId,
    string MainResponsibleUserId,
    string? DepartmentId,
    int EstimatedDurationDays,
    DateTime StartDate,
    DateTime DueDate,
    DateTime? CompletedDate,
    decimal BillingMultiplier,
    decimal BillingDuration,
    string TaskStatusId,
    string? PriorityId,
    string? Description,
    bool IsActive
) : IRequest<UpdateTaskCommandResponse>;