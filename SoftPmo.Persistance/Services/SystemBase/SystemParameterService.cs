using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.CreateSystemParameter;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Commands.UpdateSystemParameter;
using SoftPmo.Application.Features.SystemBase.SystemParameterFeatures.Queries.GetAllSystemParameters;
using SoftPmo.Application.Services.SystemBase;
using SoftPmo.Domain.Entities.SystemBase;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.SystemBase;

public sealed class SystemParameterService : ISystemParameterService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public SystemParameterService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateSystemParameterCommandResponse> CreateAsync(CreateSystemParameterCommand request, CancellationToken cancellationToken)
    {
        // Aynı anahtarla başka parametre var mı kontrol et
        var existingParameter = await _context.Set<SystemParameter>()
            .FirstOrDefaultAsync(sp => sp.ParameterName == request.ParameterKey, cancellationToken);

        if (existingParameter != null)
            throw new Exception($"'{request.ParameterKey}' anahtarıyla bir parametre zaten mevcut.");

        // Mapping
        SystemParameter systemParameter = _mapper.Map<SystemParameter>(request);

        // Otomatik kod oluştur (SYS-PARAM-001 formatında)
        var lastCode = await _context.Set<SystemParameter>()
            .Where(sp => sp.Code.StartsWith("SYS-PARAM-"))
            .OrderByDescending(sp => sp.Code)
            .Select(sp => sp.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("SYS-PARAM-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        systemParameter.Code = $"SYS-PARAM-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<SystemParameter>().AddAsync(systemParameter, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateSystemParameterCommandResponse(systemParameter.Id, systemParameter.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateSystemParameterCommand request, CancellationToken cancellationToken)
    {
        // Mevcut systemParameter'ı bul
        SystemParameter? systemParameter = await _context.Set<SystemParameter>()
            .FirstOrDefaultAsync(sp => sp.Id == request.Id, cancellationToken);

        if (systemParameter is null)
            throw new Exception("Sistem parametresi bulunamadı.");

        // Aynı anahtarla başka parametre var mı kontrol et (kendisi hariç)
        var duplicateKey = await _context.Set<SystemParameter>()
            .AnyAsync(sp => sp.ParameterName == request.ParameterKey && sp.Id != request.Id, cancellationToken);

        if (duplicateKey)
            throw new Exception($"'{request.ParameterKey}' anahtarıyla başka bir parametre zaten mevcut.");

        // Güncelle
        systemParameter.ParameterName = request.ParameterKey;
        systemParameter.ParameterValue = request.ParameterValue;
        systemParameter.Category = request.Category;
        systemParameter.IsActive = request.IsActive;
        systemParameter.UpdatedDate = DateTime.UtcNow;

        _context.Set<SystemParameter>().Update(systemParameter);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task UpdateParameterValueAsync(string parameterKey, string parameterValue, CancellationToken cancellationToken)
    {
        SystemParameter? systemParameter = await _context.Set<SystemParameter>()
            .FirstOrDefaultAsync(sp => sp.ParameterName == parameterKey && sp.IsActive, cancellationToken);

        if (systemParameter is null)
            throw new Exception($"'{parameterKey}' anahtarlı parametre bulunamadı veya aktif değil.");

        systemParameter.ParameterValue = parameterValue;
        systemParameter.UpdatedDate = DateTime.UtcNow;

        _context.Set<SystemParameter>().Update(systemParameter);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        SystemParameter? systemParameter = await _context.Set<SystemParameter>()
            .FirstOrDefaultAsync(sp => sp.Id == id, cancellationToken);

        if (systemParameter is null)
            throw new Exception("Sistem parametresi bulunamadı.");

        // Soft delete
        systemParameter.IsActive = false;
        systemParameter.UpdatedDate = DateTime.UtcNow;

        _context.Set<SystemParameter>().Update(systemParameter);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<SystemParameter>> GetAllAsync(GetAllSystemParametersQuery request, CancellationToken cancellationToken)
    {
        IQueryable<SystemParameter> query = _context.Set<SystemParameter>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(sp =>
                sp.ParameterName.ToLower().Contains(searchLower) ||
                sp.Code.ToLower().Contains(searchLower) ||
                sp.ParameterValue.ToLower().Contains(searchLower) ||
                (sp.Category != null && sp.Category.ToLower().Contains(searchLower))
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(sp => sp.IsActive == request.IsActive.Value);
        }

        // Kategori filtresi
        if (!string.IsNullOrEmpty(request.Category))
        {
            query = query.Where(sp => sp.Category == request.Category);
        }

        // Sayfalama
        var systemParameters = await query
            .OrderBy(sp => sp.Category)
            .ThenBy(sp => sp.ParameterName)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return systemParameters;
    }

    public async Task<SystemParameter> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        SystemParameter? systemParameter = await _context.Set<SystemParameter>()
            .FirstOrDefaultAsync(sp => sp.Id == id, cancellationToken);

        if (systemParameter is null)
            throw new Exception("Sistem parametresi bulunamadı.");

        return systemParameter;
    }

    public async Task<SystemParameter> GetByKeyAsync(string parameterKey, CancellationToken cancellationToken)
    {
        SystemParameter? systemParameter = await _context.Set<SystemParameter>()
            .FirstOrDefaultAsync(sp => sp.ParameterName == parameterKey && sp.IsActive, cancellationToken);

        if (systemParameter is null)
            throw new Exception($"'{parameterKey}' anahtarlı parametre bulunamadı veya aktif değil.");

        return systemParameter;
    }
}