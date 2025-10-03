using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.LocationTypeFeatures.Commands.CreateLocationType;

public sealed class CreateLocationTypeCommandHandler : IRequestHandler<CreateLocationTypeCommand, CreateLocationTypeCommandResponse>
{
    private readonly ILocationTypeService _locationTypeService;

    public CreateLocationTypeCommandHandler(ILocationTypeService locationTypeService)
    {
        _locationTypeService = locationTypeService;
    }

    public async Task<CreateLocationTypeCommandResponse> Handle(CreateLocationTypeCommand request, CancellationToken cancellationToken)
    {
        var response = await _locationTypeService.CreateAsync(request, cancellationToken);
        return response;
    }
}