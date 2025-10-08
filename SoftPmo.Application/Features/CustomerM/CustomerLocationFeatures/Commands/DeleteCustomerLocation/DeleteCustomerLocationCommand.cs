using MediatR;

namespace SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.DeleteCustomerLocation;

public sealed record DeleteCustomerLocationCommand(
    string Id
) : IRequest<DeleteCustomerLocationCommandResponse>;