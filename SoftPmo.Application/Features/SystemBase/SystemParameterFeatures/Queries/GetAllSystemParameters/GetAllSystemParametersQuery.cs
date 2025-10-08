using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetAllSystemParameters;

public sealed record GetAllSystemParametersQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string Search = "",
    bool? IsActive = null,
    string? Category = null
) : IRequest<IList<SystemParameter>>;