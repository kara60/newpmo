using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectTypeFeatures.Commands.DeleteProjectType;

public sealed record DeleteProjectTypeCommand(
    string Id
) : IRequest<DeleteProjectTypeCommandResponse>;