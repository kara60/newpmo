using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetParameterByKey;

public sealed record GetParameterByKeyQuery(
    string ParameterKey
) : IRequest<SystemParameter>;