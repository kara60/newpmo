using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.UpdateProjectType;

public sealed class UpdateProjectTypeCommandHandler : IRequestHandler<UpdateProjectTypeCommand, UpdateProjectTypeCommandResponse>
{
    private readonly IProjectTypeService _projectTypeService;

    public UpdateProjectTypeCommandHandler(IProjectTypeService projectTypeService)
    {
        _projectTypeService = projectTypeService;
    }

    public async Task<UpdateProjectTypeCommandResponse> Handle(UpdateProjectTypeCommand request, CancellationToken cancellationToken)
    {
        await _projectTypeService.UpdateAsync(request, cancellationToken);
        return new UpdateProjectTypeCommandResponse();
    }
}