using MediatR;
using SoftPmo.Domain.Entities.Project;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Queries.GetProjectsByCustomer;

public sealed record GetProjectsByCustomerQuery(
    string CustomerId
) : IRequest<IList<Domain.Entities.Project.ProjectM>>;