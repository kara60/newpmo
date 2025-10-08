using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.CreateActivity;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Commands.UpdateActivity;
using SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetAllActivities;
using SoftPmo.Domain.Entities.Activity;

namespace SoftPmo.Application.Services.ActivityM;

public interface IActivityService
{
    Task<CreateActivityCommandResponse> CreateAsync(CreateActivityCommand request, CancellationToken cancellationToken);
    Task UpdateAsync(UpdateActivityCommand request, CancellationToken cancellationToken);
    Task DeleteAsync(string id, CancellationToken cancellationToken);
    Task ApproveAsync(string id, string approvedByUserId, bool isApproved, string? approvalNote, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Activity.ActivityM>> GetAllAsync(GetAllActivitiesQuery request, CancellationToken cancellationToken);
    Task<Domain.Entities.Activity.ActivityM> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Activity.ActivityM>> GetByUserAsync(string userId, DateTime? startDate, DateTime? endDate, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Activity.ActivityM>> GetByTaskAsync(string taskId, CancellationToken cancellationToken);
    Task<IList<Domain.Entities.Activity.ActivityM>> GetPendingApprovalsAsync(string? managerId, CancellationToken cancellationToken);
}