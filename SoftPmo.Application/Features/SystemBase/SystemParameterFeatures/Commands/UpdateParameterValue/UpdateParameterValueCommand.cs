using MediatR;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateParameterValue;

public sealed record UpdateParameterValueCommand(
    string ParameterKey,
    string ParameterValue
) : IRequest<UpdateParameterValueCommandResponse>;