namespace SoftPmo.Application.Features.HumanResources.UserFeatures.Commands.CreateUser;

public sealed record CreateUserCommandResponse(
    string Id,
    string Code,
    string FullName,
    string Message = "Personel başarıyla oluşturuldu."
);