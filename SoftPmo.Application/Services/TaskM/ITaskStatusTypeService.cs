using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.CreateTaskStatusType;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Commands.UpdateTaskStatusType;
using SoftPmo.Application.Features.TaskM.TaskStatusTypeFeatures.Queries.GetAllTaskStatusTypes;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Services.TaskM;

public interface ITaskStatusTypeService
{
    Task<CreateTaskStatusTypeCommandResponse> CreateAsync(CreateTaskStatusTypeCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateTaskStatusTypeCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<TaskStatusType>> GetAllAsync(GetAllTaskStatusTypesQuery request, CancellationToken cancellationToken);
    Task<TaskStatusType> GetByIdAsync(string id, CancellationToken cancellationToken);
}