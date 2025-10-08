using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.CreateCustomerLocation;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Commands.UpdateCustomerLocation;
using SoftPmo.Application.Features.CustomerM.CustomerLocationFeatures.Queries.GetAllCustomerLocations;
using SoftPmo.Application.Services.CustomerM;
using SoftPmo.Domain.Entities.Customer;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.CustomerM;

public sealed class CustomerLocationService : ICustomerLocationService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public CustomerLocationService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateCustomerLocationCommandResponse> CreateAsync(CreateCustomerLocationCommand request, CancellationToken cancellationToken)
    {
        // Customer kontrolü
        var customerExists = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .AnyAsync(c => c.Id == request.CustomerId && c.IsActive, cancellationToken);

        if (!customerExists)
            throw new Exception("Müşteri bulunamadı veya aktif değil.");

        // Eğer IsDefault true ise, diğer lokasyonların IsDefault'unu false yap
        if (request.IsDefault)
        {
            var existingLocations = await _context.Set<CustomerLocation>()
                .Where(cl => cl.CustomerId == request.CustomerId && cl.IsDefault)
                .ToListAsync(cancellationToken);

            foreach (var location in existingLocations)
            {
                location.IsDefault = false;
            }
        }

        // Mapping
        CustomerLocation customerLocation = _mapper.Map<CustomerLocation>(request);

        // Otomatik kod oluştur (CUS-LOC-001 formatında)
        var lastCode = await _context.Set<CustomerLocation>()
            .Where(cl => cl.Code.StartsWith("CUS-LOC-"))
            .OrderByDescending(cl => cl.Code)
            .Select(cl => cl.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("CUS-LOC-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        customerLocation.Code = $"CUS-LOC-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<CustomerLocation>().AddAsync(customerLocation, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateCustomerLocationCommandResponse(customerLocation.Id, customerLocation.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateCustomerLocationCommand request, CancellationToken cancellationToken)
    {
        // Mevcut customerLocation'ı bul
        CustomerLocation? customerLocation = await _context.Set<CustomerLocation>()
            .FirstOrDefaultAsync(cl => cl.Id == request.Id, cancellationToken);

        if (customerLocation is null)
            throw new Exception("Müşteri lokasyonu bulunamadı.");

        // Customer kontrolü
        var customerExists = await _context.Set<Domain.Entities.Customer.CustomerM>()
            .AnyAsync(c => c.Id == request.CustomerId && c.IsActive, cancellationToken);

        if (!customerExists)
            throw new Exception("Müşteri bulunamadı veya aktif değil.");

        // Eğer IsDefault true yapılıyorsa, diğerlerini false yap
        if (request.IsDefault && !customerLocation.IsDefault)
        {
            var otherLocations = await _context.Set<CustomerLocation>()
                .Where(cl => cl.CustomerId == request.CustomerId && cl.IsDefault && cl.Id != request.Id)
                .ToListAsync(cancellationToken);

            foreach (var location in otherLocations)
            {
                location.IsDefault = false;
            }
        }

        // Güncelle
        customerLocation.CustomerId = request.CustomerId;
        customerLocation.LocationName = request.LocationName;
        customerLocation.Address = request.Address;
        customerLocation.Phone = request.Phone;
        //customerLocation.LocationType = request.LocationType;
        customerLocation.IsDefault = request.IsDefault;
        customerLocation.IsActive = request.IsActive;
        customerLocation.UpdatedDate = DateTime.UtcNow;

        _context.Set<CustomerLocation>().Update(customerLocation);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        CustomerLocation? customerLocation = await _context.Set<CustomerLocation>()
            .Include(cl => cl.Activities)
            .FirstOrDefaultAsync(cl => cl.Id == id, cancellationToken);

        if (customerLocation is null)
            throw new Exception("Müşteri lokasyonu bulunamadı.");

        // Bu lokasyonda faaliyetler var mı kontrol et
        if (customerLocation.Activities.Any(a => a.IsActive))
            throw new Exception("Bu lokasyonda aktif faaliyetler var. Önce faaliyetleri taşıyın.");

        // Soft delete
        customerLocation.IsActive = false;
        customerLocation.UpdatedDate = DateTime.UtcNow;

        _context.Set<CustomerLocation>().Update(customerLocation);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<CustomerLocation>> GetAllAsync(GetAllCustomerLocationsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<CustomerLocation> query = _context.Set<CustomerLocation>()
            .Include(cl => cl.Customer)
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(cl =>
                cl.LocationName.ToLower().Contains(searchLower) ||
                cl.Code.ToLower().Contains(searchLower) ||
                (cl.Address != null && cl.Address.ToLower().Contains(searchLower))
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(cl => cl.IsActive == request.IsActive.Value);
        }

        // Müşteri filtresi
        if (!string.IsNullOrEmpty(request.CustomerId))
        {
            query = query.Where(cl => cl.CustomerId == request.CustomerId);
        }

        // Sayfalama
        var customerLocations = await query
            .OrderBy(cl => cl.Customer.Name)
            .ThenBy(cl => cl.LocationName)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return customerLocations;
    }

    public async Task<CustomerLocation> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        CustomerLocation? customerLocation = await _context.Set<CustomerLocation>()
            .Include(cl => cl.Customer)
            .FirstOrDefaultAsync(cl => cl.Id == id, cancellationToken);

        if (customerLocation is null)
            throw new Exception("Müşteri lokasyonu bulunamadı.");

        return customerLocation;
    }

    public async Task<IList<CustomerLocation>> GetByCustomerAsync(string customerId, CancellationToken cancellationToken)
    {
        var customerLocations = await _context.Set<CustomerLocation>()
            .Where(cl => cl.CustomerId == customerId && cl.IsActive)
            .OrderByDescending(cl => cl.IsDefault)
            .ThenBy(cl => cl.LocationName)
            .ToListAsync(cancellationToken);

        return customerLocations;
    }
}