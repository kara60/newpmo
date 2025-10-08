using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.DeleteProjectStatus;

public sealed record DeleteProjectStatusCommand(
    string Id
) : IRequest<DeleteProjectStatusCommandResponse>;