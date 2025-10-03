using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.CreatePriority;

public sealed class CreatePriorityCommandHandler : IRequestHandler<CreatePriorityCommand, CreatePriorityCommandResponse>
{
    private readonly IPriorityService _priorityService;

    public CreatePriorityCommandHandler(IPriorityService priorityService)
    {
        _priorityService = priorityService;
    }

    public async Task<CreatePriorityCommandResponse> Handle(CreatePriorityCommand request, CancellationToken cancellationToken)
    {
        var response = await _priorityService.CreateAsync(request, cancellationToken);
        return response;
    }
}