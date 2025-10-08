using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.CreateCustomer;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Commands.UpdateCustomer;
using SoftPmo.Application.Features.CustomerM.CustomerFeatures.Queries.GetAllCustomers;
using SoftPmo.Application.Services.CustomerM;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.CustomerM;

public sealed class CustomerService : ICustomerService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CustomerService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateCustomerCommandResponse> CreateAsync(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        Domain.Entities.Customer.CustomerM customer = _mapper.Map<Domain.Entities.Customer.CustomerM>(request);

        // Otomatik kod oluştur (CUS-001 formatında)
        var lastCode = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .Where(c => c.Code.StartsWith("CUS-"))
            .OrderByDescending(c => c.Code)
            .Select(c => c.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("CUS-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        customer.Code = $"CUS-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<Domain.Entities.Customer.CustomerM>().AddAsync(customer, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateCustomerCommandResponse(customer.Id, customer.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        // Mevcut customer'ı bul
        Domain.Entities.Customer.CustomerM? customer = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

        if (customer is null)
            throw new Exception("Müşteri bulunamadı.");

        // Güncelle
        customer.Name = request.Name;
        customer.TaxNumber = request.TaxNumber;
        customer.Phone = request.Phone;
        customer.Email = request.Email;
        customer.Address = request.Address;
        customer.HasMaintenanceContract = request.HasMaintenanceContract;
        customer.MonthlyMaintenanceFee = request.MonthlyMaintenanceFee;
        customer.MaintenanceStartDate = request.MaintenanceStartDate;
        customer.MaintenanceEndDate = request.MaintenanceEndDate;
        customer.PrimaryContactName = request.PrimaryContactName;
        customer.PrimaryContactEmail = request.PrimaryContactEmail;
        customer.TechnicalContactName = request.TechnicalContactName;
        customer.TechnicalContactEmail = request.TechnicalContactEmail;
        customer.IsActive = request.IsActive;
        customer.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Customer.CustomerM>().Update(customer);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Customer.CustomerM? customer = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .Include(c => c.Projects)
            .Include(c => c.Tasks)
            .Include(c => c.CustomerLocations)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (customer is null)
            throw new Exception("Müşteri bulunamadı.");

        // Bu müşteride aktif projeler veya işler var mı kontrol et
        bool hasActiveProjects = customer.Projects.Any(p => p.IsActive);
        bool hasActiveTasks = customer.Tasks.Any(t => t.IsActive);

        if (hasActiveProjects || hasActiveTasks)
            throw new Exception("Bu müşteride aktif projeler veya işler var. Önce bunları kapatın.");

        // Soft delete
        customer.IsActive = false;
        customer.UpdatedDate = DateTime.UtcNow;

        _context.Set<Domain.Entities.Customer.CustomerM>().Update(customer);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Domain.Entities.Customer.CustomerM>> GetAllAsync(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Domain.Entities.Customer.CustomerM> query = _context.Set<Domain.Entities.Customer.CustomerM>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(c =>
                c.Name.ToLower().Contains(searchLower) ||
                c.Code.ToLower().Contains(searchLower) ||
                (c.TaxNumber != null && c.TaxNumber.ToLower().Contains(searchLower)) ||
                (c.Email != null && c.Email.ToLower().Contains(searchLower))
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(c => c.IsActive == request.IsActive.Value);
        }

        // Bakım sözleşmesi filtresi
        if (request.HasMaintenanceContract.HasValue)
        {
            query = query.Where(c => c.HasMaintenanceContract == request.HasMaintenanceContract.Value);
        }

        // Sayfalama
        var customers = await query
            .OrderBy(c => c.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return customers;
    }

    public async Task<Domain.Entities.Customer.CustomerM> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Customer.CustomerM? customer = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (customer is null)
            throw new Exception("Müşteri bulunamadı.");

        return customer;
    }

    public async Task<Domain.Entities.Customer.CustomerM> GetWithDetailsAsync(string id, CancellationToken cancellationToken)
    {
        Domain.Entities.Customer.CustomerM? customer = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .Include(c => c.CustomerLocations)
            .Include(c => c.Projects)
                .ThenInclude(p => p.ProjectStatus)
            .Include(c => c.Tasks)
                .ThenInclude(t => t.TaskStatus)
            .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

        if (customer is null)
            throw new Exception("Müşteri bulunamadı.");

        return customer;
    }
}