using MediatR;
using SoftPmo.Domain.Entities.Activity;
using System.ComponentModel;

namespace SoftPmo.Application.Features.ActivityM.ActivityFeatures.Queries.GetAllActivities;

public sealed record GetAllActivitiesQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    bool? IsApproved = null,
    string? UserId = null,
    string? TaskId = null,
    DateTime? StartDate = null,
    DateTime? EndDate = null
) : IRequest<IList<Domain.Entities.Activity.ActivityM>>;