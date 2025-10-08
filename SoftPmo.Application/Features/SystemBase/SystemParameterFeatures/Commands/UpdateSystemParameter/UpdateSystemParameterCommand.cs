using MediatR;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateSystemParameter;

public sealed record UpdateSystemParameterCommand(
    string Id,
    string ParameterKey,
    string ParameterValue,
    string? Description,
    string? Category,
    bool IsActive
) : IRequest<UpdateSystemParameterCommandResponse>;