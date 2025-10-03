using MediatR;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.CodeTemplateFeatures.Queries.GetAllCodeTemplates;

public sealed record GetAllCodeTemplateQuery(
    int pageNumber = 1,
    int pageSize = 10,
    string Search = ""
    ) : IRequest<IList<CodeTemplate>>;