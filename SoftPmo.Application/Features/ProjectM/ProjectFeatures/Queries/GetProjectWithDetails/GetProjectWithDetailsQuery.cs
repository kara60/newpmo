using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetProjectWithDetails;

public sealed record GetProjectWithDetailsQuery(
    string Id
) : IRequest<Domain.Entities.Project.ProjectM>;