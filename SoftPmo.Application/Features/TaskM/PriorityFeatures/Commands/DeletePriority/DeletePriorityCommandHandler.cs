using MediatR;
using SoftPmo.Application.Services.TaskM;

namespace SoftPmo.Application.Features.TaskM.PriorityFeatures.Commands.DeletePriority;

public sealed class DeletePriorityCommandHandler : IRequestHandler<DeletePriorityCommand, DeletePriorityCommandResponse>
{
    private readonly IPriorityService _priorityService;

    public DeletePriorityCommandHandler(IPriorityService priorityService)
    {
        _priorityService = priorityService;
    }

    public async Task<DeletePriorityCommandResponse> Handle(DeletePriorityCommand request, CancellationToken cancellationToken)
    {
        await _priorityService.DeleteAsync(request.Id, cancellationToken);
        return new DeletePriorityCommandResponse();
    }
}