using MediatR;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.CreateCustomer;

public sealed record CreateCustomerCommand(
    string Name,
    string? TaxNumber,
    string? Phone,
    string? Email,
    string? Address,
    bool HasMaintenanceContract,
    decimal? MonthlyMaintenanceFee,
    DateTime? MaintenanceStartDate,
    DateTime? MaintenanceEndDate,
    bool? AutoRenewMaintenance,
    string? PrimaryContactName,
    string? PrimaryContactEmail,
    string? PrimaryContactPhone,
    string? TechnicalContactName,
    string? TechnicalContactEmail,
    string? TechnicalContactPhone,
    string? Description
) : IRequest<CreateCustomerCommandResponse>;