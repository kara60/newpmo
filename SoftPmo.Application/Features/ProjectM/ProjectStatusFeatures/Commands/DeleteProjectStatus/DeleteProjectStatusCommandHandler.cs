using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.DeleteProjectStatus;

public sealed class DeleteProjectStatusCommandHandler : IRequestHandler<DeleteProjectStatusCommand, DeleteProjectStatusCommandResponse>
{
    private readonly IProjectStatusService _projectStatusService;

    public DeleteProjectStatusCommandHandler(IProjectStatusService projectStatusService)
    {
        _projectStatusService = projectStatusService;
    }

    public async Task<DeleteProjectStatusCommandResponse> Handle(DeleteProjectStatusCommand request, CancellationToken cancellationToken)
    {
        await _projectStatusService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteProjectStatusCommandResponse();
    }
}