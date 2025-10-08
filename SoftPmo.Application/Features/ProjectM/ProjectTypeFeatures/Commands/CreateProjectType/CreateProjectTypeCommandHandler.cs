using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.CreateProjectType;

public sealed class CreateProjectTypeCommandHandler : IRequestHandler<CreateProjectTypeCommand, CreateProjectTypeCommandResponse>
{
    private readonly IProjectTypeService _projectTypeService;

    public CreateProjectTypeCommandHandler(IProjectTypeService projectTypeService)
    {
        _projectTypeService = projectTypeService;
    }

    public async Task<CreateProjectTypeCommandResponse> Handle(CreateProjectTypeCommand request, CancellationToken cancellationToken)
    {
        var response = await _projectTypeService.CreateAsync(request, cancellationToken);
        return response;
    }
}