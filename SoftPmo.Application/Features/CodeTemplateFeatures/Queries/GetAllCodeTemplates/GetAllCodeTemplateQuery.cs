using MediatR;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Application.Features.CodeTemplateFeatures.Queries.GetAllCodeTemplates;

public sealed record GetAllCodeTemplateQuery(
    int pageNumber = 1,
    int pageSize = 10,
    string Search = ""
    ) : IRequest<IList<CodeTemplate>>;