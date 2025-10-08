using MediatR;

namespace SoftPmo.Application.Features.ProjectM.ProjectStatusFeatures.Commands.CreateProjectStatus;

public sealed record CreateProjectStatusCommand(
    string Name,
    string StatusType,
    int SortOrder,
    string? ColorCode,
    string? Description
) : IRequest<CreateProjectStatusCommandResponse>;