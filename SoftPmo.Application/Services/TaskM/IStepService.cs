using SoftPmo.Application.Features.TaskM.StepFeatures.Commands.CreateStep;
using SoftPmo.Application.Features.TaskM.StepFeatures.Commands.UpdateStep;
using SoftPmo.Application.Features.TaskM.StepFeatures.Queries.GetAllSteps;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Services.TaskM;

public interface IStepService
{
    Task<CreateStepCommandResponse> CreateAsync(CreateStepCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateStepCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task<IList<Step>> GetAllAsync(GetAllStepsQuery request, CancellationToken cancellationToken);
    Task<Step> GetByIdAsync(string id, CancellationToken cancellationToken);
}