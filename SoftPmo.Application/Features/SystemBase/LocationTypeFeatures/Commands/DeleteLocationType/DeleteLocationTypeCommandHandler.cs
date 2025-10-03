using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.DeleteLocationType;

public sealed class DeleteLocationTypeCommandHandler : IRequestHandler<DeleteLocationTypeCommand, DeleteLocationTypeCommandResponse>
{
    private readonly ILocationTypeService _locationTypeService;

    public DeleteLocationTypeCommandHandler(ILocationTypeService locationTypeService)
    {
        _locationTypeService = locationTypeService;
    }

    public async Task<DeleteLocationTypeCommandResponse> Handle(DeleteLocationTypeCommand request, CancellationToken cancellationToken)
    {
        await _locationTypeService.DeleteAsync(request.Id, cancellationToken);
        return new DeleteLocationTypeCommandResponse();
    }
}