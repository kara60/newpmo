using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetProjectById;

public sealed record GetProjectByIdQuery(
    string Id
) : IRequest<Domain.Entities.Project.ProjectM>;