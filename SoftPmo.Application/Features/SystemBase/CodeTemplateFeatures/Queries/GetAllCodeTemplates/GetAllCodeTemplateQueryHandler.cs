using MediatR;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.CodeTemplateFeatures.Queries.GetAllCodeTemplates;

public sealed class GetAllCodeTemplateQueryHandler : IRequestHandler<GetAllCodeTemplateQuery, IList<CodeTemplate>>
{
    private readonly ICodeTemplateService _codeTemplateService;

    public GetAllCodeTemplateQueryHandler(ICodeTemplateService codeTemplateService)
    {
        _codeTemplateService = codeTemplateService;
    }

    public async Task<IList<CodeTemplate>> Handle(GetAllCodeTemplateQuery request, CancellationToken cancellationToken)
    {
        IList<CodeTemplate> codeTemplates = await _codeTemplateService.GetAllAsync(request, cancellationToken);
        return codeTemplates;
    }
}