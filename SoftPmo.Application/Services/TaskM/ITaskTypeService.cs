using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.CreateTaskType;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Commands.UpdateTaskType;
using SoftPmo.Application.Features.TaskM.TaskTypeFeatures.Queries.GetAllTaskTypes;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Services.TaskM;

public interface ITaskTypeService
{
    Task<CreateTaskTypeCommandResponse> CreateAsync(CreateTaskTypeCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateTaskTypeCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<TaskType>> GetAllAsync(GetAllTaskTypesQuery request, CancellationToken cancellationToken);
    Task<TaskType> GetByIdAsync(string id, CancellationToken cancellationToken);
}