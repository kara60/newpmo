using MediatR;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.CreateSystemParameter;

public sealed record CreateSystemParameterCommand(
    string ParameterKey,
    string ParameterValue,
    string? Description,
    string? Category
) : IRequest<CreateSystemParameterCommandResponse>;