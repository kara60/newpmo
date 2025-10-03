using MediatR;
using SoftPmo.Application.Services.SystemBase;

namespace SoftPmo.Application.Features.SystemBase.LocationFeatures.Commands.CreateLocation;

public sealed class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, CreateLocationCommandResponse>
{
    private readonly ILocationService _locationService;

    public CreateLocationCommandHandler(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public async Task<CreateLocationCommandResponse> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
    {
        var response = await _locationService.CreateAsync(request, cancellationToken);
        return response;
    }
}
