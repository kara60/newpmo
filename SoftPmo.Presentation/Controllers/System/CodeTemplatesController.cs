using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoftPmo.Application.Features.CodeTemplateFeatures.Commands.System.CreateCodeTemplate;
using SoftPmo.Presentation.Abstraction;

namespace SoftPmo.Presentation.Controllers.System;

public sealed class CodeTemplatesController : ApiController
{
    public CodeTemplatesController(IMediator mediator) : base(mediator){}

    [HttpPost("[action]")]
    public async Task<IActionResult> Create(CreateCodeTemplateCommand request, CancellationToken cancellationToken)
    {
        CreateCodeTemplateCommandResponse response = await _mediator.Send(request, cancellationToken);
        return Ok(response);
    }
}