using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetSystemParameterById;

public sealed record GetSystemParameterByIdQuery(
    string Id
) : IRequest<SystemParameter>;