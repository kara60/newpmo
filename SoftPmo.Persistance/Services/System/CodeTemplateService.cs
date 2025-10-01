using AutoMapper;
using SoftPmo.Application.Features.CodeTemplateFeatures.Commands.System.CreateCodeTemplate;
using SoftPmo.Application.Services.System;
using SoftPmo.Domain.Entities.System;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.System;

public sealed class CodeTemplateService : ICodeTemplateService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CodeTemplateService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task CreateAsync(CreateCodeTemplateCommand request, CancellationToken cancellationToken)
    {
        CodeTemplate codeTemplate = _mapper.Map<CodeTemplate>(request);
        
        await _context.Set<CodeTemplate>().AddAsync(codeTemplate, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}