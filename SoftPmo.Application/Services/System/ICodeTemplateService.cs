using SoftPmo.Application.Features.CodeTemplateFeatures.Commands.System.CreateCodeTemplate;

namespace SoftPmo.Application.Services.System;

public interface ICodeTemplateService
{
    Task CreateAsync(CreateCodeTemplateCommand request, CancellationToken cancellationToken);
}
