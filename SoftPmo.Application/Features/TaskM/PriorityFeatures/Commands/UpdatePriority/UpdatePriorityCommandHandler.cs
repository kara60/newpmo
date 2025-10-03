using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.UpdatePriority;

public sealed class UpdatePriorityCommandHandler : IRequestHandler<UpdatePriorityCommand, UpdatePriorityCommandResponse>
{
    private readonly IPriorityService _priorityService;

    public UpdatePriorityCommandHandler(IPriorityService priorityService)
    {
        _priorityService = priorityService;
    }

    public async Task<UpdatePriorityCommandResponse> Handle(UpdatePriorityCommand request, CancellationToken cancellationToken)
    {
        await _priorityService.UpdateAsync(request, cancellationToken);
        return new UpdatePriorityCommandResponse();
    }
}