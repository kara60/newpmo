using MediatR;

namespace SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.UpdateCustomer;

public sealed record UpdateCustomerCommand(
    string Id,
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
    string? Description,
    bool IsActive
) : IRequest<UpdateCustomerCommandResponse>;