using MediatR;
using SoftPmo.Application.Services.System;

namespace SoftPmo.Application.Features.LocationFeatures.Commands.DeleteLocation;

public sealed class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, DeleteLocationCommandResponse>
{
    private readonly ILocationService _locationService;

    public DeleteLocationCommandHandler(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public async Task<DeleteLocationCommandResponse> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
    {
        await _locationService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteLocationCommandResponse();
    }
}