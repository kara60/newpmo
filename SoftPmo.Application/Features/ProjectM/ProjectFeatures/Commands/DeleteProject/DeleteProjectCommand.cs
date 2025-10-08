using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectFeatures.Commands.DeleteProject;

public sealed record DeleteProjectCommand(
    string Id
) : IRequest<DeleteProjectCommandResponse>;