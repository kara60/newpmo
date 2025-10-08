using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Queries.GetProjectTypeById;

public sealed record GetProjectTypeByIdQuery(
    string Id
) : IRequest<ProjectType>;