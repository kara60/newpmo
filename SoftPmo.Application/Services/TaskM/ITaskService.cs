using SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.CreateTask;
using SoftPmo.Application.Features.TaskM.TaskFeatures.Commands.UpdateTask;
using SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetAllTasks;

namespace SoftPmo.Application.Services.TaskM;

public interface ITaskService
{
    Task<CreateTaskCommandResponse> CreateAsync(CreateTaskCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateTaskCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task ChangeStatusAsync(string id, string taskStatusId, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Task.TaskM>> GetAllAsync(GetAllTasksQuery request, CancellationToken cancellationToken);
    Task<Domain.Entities.Task.TaskM> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Task.TaskM>> GetByProjectAsync(string projectId, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Task.TaskM>> GetByUserAsync(string userId, CancellationToken cancellationToken);
    Task<Domain.Entities.Task.TaskM> GetWithDetailsAsync(string id, CancellationToken cancellationToken);
}