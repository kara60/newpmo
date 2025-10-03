using SoftPmo.Application.Features.CodeTemplateFeatures.Commands.System.CreateCodeTemplate;
using SoftPmo.Application.Features.CodeTemplateFeatures.Queries.GetAllCodeTemplates;
using SoftPmo.Domain.Entities.System;

namespace SoftPmo.Application.Services.System;

public interface ICodeTemplateService
{
    Task CreateAsync(CreateCodeTemplateCommand request, CancellationToken cancellationToken);
    Task<IList<CodeTemplate>> GetAllAsync(GetAllCodeTemplateQuery request, CancellationToken cancellationToken);
}
