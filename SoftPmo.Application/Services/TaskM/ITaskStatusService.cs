using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.CreateTaskStatus;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Commands.UpdateTaskStatus;
using SoftPmo.Application.Features.TaskM.TaskStatusFeatures.Queries.GetAllTaskStatuses;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Services.TaskM;

public interface ITaskStatusService
{
    Task<CreateTaskStatusCommandResponse> CreateAsync(CreateTaskStatusCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateTaskStatusCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Task.TaskStatus>> GetAllAsync(GetAllTaskStatusesQuery request, CancellationToken cancellationToken);
    Task<Domain.Entities.Task.TaskStatus> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Task.TaskStatus>> GetByTypeAsync(string taskStatusTypeId, CancellationToken cancellationToken);
}