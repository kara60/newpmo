using SoftPmo.Application.Features.SystemBase.CodeTemplateFeatures.Commands.CreateCodeTemplate;
using SoftPmo.Application.Features.SystemBase.CodeTemplateFeatures.Queries.GetAllCodeTemplates;
using SoftPmo.Domain.Entities.SystemBase;

namespace SoftPmo.Application.Services.SystemBase;

public interface ICodeTemplateService
{
    Task CreateAsync(CreateCodeTemplateCommand request, CancellationToken cancellationToken);
    Task<IList<CodeTemplate>> GetAllAsync(GetAllCodeTemplateQuery request, CancellationToken cancellationToken);
}
