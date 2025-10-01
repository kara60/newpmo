using SoftPmo.Application.Features.CodeTemplateFeatures.Commands.System.CreateCodeTemplate;
using SoftPmo.Application.Services.System;
using SoftPmo.Domain.Entities.System;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.System;

public sealed class CodeTemplateService : ICodeTemplateService
{
    private readonly AppDbContext _context;

    public CodeTemplateService(AppDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(CreateCodeTemplateCommand request, CancellationToken cancellationToken)
    {
        CodeTemplate codeTemplate = new()
        {
            EntityType = request.EntityType,
            CodeFormat = request.CodeFormat,
            Prefix = request.Prefix,
            UseYear = request.UserYear,
            SequenceLength = request.SequenceLength,
            StartingNumber = request.StartingNumber,
            CurrentNumber = request.CurrentNumber
        };

        await _context.Set<CodeTemplate>().AddAsync(codeTemplate, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}