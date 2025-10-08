using MediatR;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.CreateTask;

public sealed record CreateTaskCommand(
    string Title,
    string CustomerId,
    string ProjectId,
    string TaskTypeId,
    string MainResponsibleUserId,
    string? DepartmentId,
    int EstimatedDurationDays,
    DateTime StartDate,
    DateTime DueDate,
    decimal BillingMultiplier,
    decimal BillingDuration,
    string TaskStatusId,
    string? PriorityId,
    string? Description
) : IRequest<CreateTaskCommandResponse>;