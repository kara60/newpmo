using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.UpdateLocationType;

public sealed class UpdateLocationTypeCommandHandler : IRequestHandler<UpdateLocationTypeCommand, UpdateLocationTypeCommandResponse>
{
    private readonly ILocationTypeService _locationTypeService;

    public UpdateLocationTypeCommandHandler(ILocationTypeService locationTypeService)
    {
        _locationTypeService = locationTypeService;
    }

    public async Task<UpdateLocationTypeCommandResponse> Handle(UpdateLocationTypeCommand request, CancellationToken cancellationToken)
    {
        await _locationTypeService.UpdateAsync(request, cancellationToken);
        return new UpdateLocationTypeCommandResponse();
    }
}