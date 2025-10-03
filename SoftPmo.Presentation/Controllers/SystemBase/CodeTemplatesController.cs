using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.SystemBase.CodeTemplateFeatures.Queries.GetAllCodeTemplates;
using SoftPmo.Application.Features.SystemBase.CodeTemplateFeatures.Commands.CreateCodeTemplate;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.SystemBase;

public sealed class CodeTemplatesController : ApiController
{
    public CodeTemplatesController(IMediator mediator) : base(mediator) { }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCodeTemplateCommand request, CancellationToken cancellationToken)
    {
        CreateCodeTemplateCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var request = new GetAllCodeTemplateQuery();
        IList<CodeTemplate> response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}