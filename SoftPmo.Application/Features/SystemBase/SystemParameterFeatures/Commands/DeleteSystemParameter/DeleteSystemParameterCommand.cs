using MediatR;

namespace SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.DeleteSystemParameter;

public sealed record DeleteSystemParameterCommand(
    string Id
) : IRequest<DeleteSystemParameterCommandResponse>;