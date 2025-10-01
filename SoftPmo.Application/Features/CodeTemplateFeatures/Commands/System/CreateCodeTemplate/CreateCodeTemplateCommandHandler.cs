using MediatR;
using SoftPmo.Application.Services.System;

namespace SoftPmo.Application.Features.CodeTemplateFeatures.Commands.System.CreateCodeTemplate;

public sealed class CreateCodeTemplateCommandHandler : IRequestHandler<CreateCodeTemplateCommand, CreateCodeTemplateCommandResponse>
{
    private readonly ICodeTemplateService _codeTemplateService;

    public CreateCodeTemplateCommandHandler(ICodeTemplateService codeTemplateService)
    {
        _codeTemplateService = codeTemplateService;
    }

    public async Task<CreateCodeTemplateCommandResponse> Handle(CreateCodeTemplateCommand request, CancellationToken cancellationToken)
    {
        await _codeTemplateService.CreateAsync(request, cancellationToken);
        return new("Kod Numaratorü başarıyla oluşturuldu.");
    }
}
