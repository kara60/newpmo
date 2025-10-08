using MediatR;
using SoftPmo.Domain.Entities.Task;

namespace SoftPmo.Application.Features.TaskM.TaskFeatures.Queries.GetTasksByProject;

public sealed record GetTasksByProjectQuery(
    string ProjectId
) : IRequest<IList<Domain.Entities.Task.TaskM>>;