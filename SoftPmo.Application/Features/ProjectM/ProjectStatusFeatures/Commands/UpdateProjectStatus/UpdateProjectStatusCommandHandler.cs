using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.UpdateProjectStatus;

public sealed class UpdateProjectStatusCommandHandler : IRequestHandler<UpdateProjectStatusCommand, UpdateProjectStatusCommandResponse>
{
    private readonly IProjectStatusService _projectStatusService;

    public UpdateProjectStatusCommandHandler(IProjectStatusService projectStatusService)
    {
        _projectStatusService = projectStatusService;
    }

    public async Task<UpdateProjectStatusCommandResponse> Handle(UpdateProjectStatusCommand request, CancellationToken cancellationToken)
    {
        await _projectStatusService.UpdateAsync(request, cancellationToken);
        return new UpdateProjectStatusCommandResponse();
    }
}