using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.DeleteProjectType;

public sealed class DeleteProjectTypeCommandHandler : IRequestHandler<DeleteProjectTypeCommand, DeleteProjectTypeCommandResponse>
{
    private readonly IProjectTypeService _projectTypeService;

    public DeleteProjectTypeCommandHandler(IProjectTypeService projectTypeService)
    {
        _projectTypeService = projectTypeService;
    }

    public async Task<DeleteProjectTypeCommandResponse> Handle(DeleteProjectTypeCommand request, CancellationToken cancellationToken)
    {
        await _projectTypeService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteProjectTypeCommandResponse();
    }
}