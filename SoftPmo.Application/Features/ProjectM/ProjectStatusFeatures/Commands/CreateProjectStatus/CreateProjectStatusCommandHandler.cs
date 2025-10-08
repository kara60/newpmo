using MediatR;
using SoftPmo.Application.Services.ProjectM;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.CreateProjectStatus;

public sealed class CreateProjectStatusCommandHandler : IRequestHandler<CreateProjectStatusCommand, CreateProjectStatusCommandResponse>
{
    private readonly IProjectStatusService _projectStatusService;

    public CreateProjectStatusCommandHandler(IProjectStatusService projectStatusService)
    {
        _projectStatusService = projectStatusService;
    }

    public async Task<CreateProjectStatusCommandResponse> Handle(CreateProjectStatusCommand request, CancellationToken cancellationToken)
    {
        var response = await _projectStatusService.CreateAsync(request, cancellationToken);
        return response;
    }
}