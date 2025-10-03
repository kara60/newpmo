using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.CreatePriority;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.UpdatePriority;
using SoftPmo.Application.Features.TaskM.PriorityFeatures.Queries.GetAllPriorities;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Services.TaskM;

public interface IPriorityService
{
    Task<CreatePriorityCommandResponse> CreateAsync(CreatePriorityCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdatePriorityCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<Priority>> GetAllAsync(GetAllPrioritiesQuery request, CancellationToken cancellationToken);
    Task<Priority> GetByIdAsync(string id, CancellationToken cancellationToken);
}