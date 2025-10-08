using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SoftPmo.Application.Features.TaskM.StepFeatures.Commands.CreateStep;
using SoftPmo.Application.Features.TaskM.StepFeatures.Commands.UpdateStep;
using SoftPmo.Application.Features.TaskM.StepFeatures.Queries.GetAllSteps;
using SoftPmo.Application.Services.TaskM;
using SoftPmo.Domain.Entities.Task;
using SoftPmo.Persistance.Context;

namespace SoftPmo.Persistance.Services.TaskM;

public sealed class StepService : IStepService
{
    private readonly AppDbContext _context;
    private readonly IMapper _mapper;

    public StepService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CreateStepCommandResponse> CreateAsync(CreateStepCommand request, CancellationToken cancellationToken)
    {
        // Mapping
        Step step = _mapper.Map<Step>(request);

        // Otomatik kod oluştur (STEP-001 formatında)
        var lastCode = await _context.Set<Step>()
            .Where(s => s.Code.StartsWith("STEP-"))
            .OrderByDescending(s => s.Code)
            .Select(s => s.Code)
            .FirstOrDefaultAsync(cancellationToken);

        int nextNumber = 1;
        if (!string.IsNullOrEmpty(lastCode))
        {
            var numberPart = lastCode.Replace("STEP-", "");
            if (int.TryParse(numberPart, out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }
        step.Code = $"STEP-{nextNumber:D3}";

        // Veritabanına ekle
        await _context.Set<Step>().AddAsync(step, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateStepCommandResponse(step.Id, step.Code);
    }

    public async System.Threading.Tasks.Task UpdateAsync(UpdateStepCommand request, CancellationToken cancellationToken)
    {
        // Mevcut step'i bul
        Step? step = await _context.Set<Step>()
            .FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken);

        if (step is null)
            throw new Exception("İş adımı bulunamadı.");

        // Güncelle
        step.Name = request.Name;
        step.IsActive = request.IsActive;
        step.UpdatedDate = DateTime.UtcNow;

        _context.Set<Step>().Update(step);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async System.Threading.Tasks.Task DeleteAsync(string id, CancellationToken cancellationToken)
    {
        Step? step = await _context.Set<Step>()
            .Include(s => s.TaskSteps)
            .Include(s => s.TaskTypeSteps)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (step is null)
            throw new Exception("İş adımı bulunamadı.");

        // Bu adımda aktif task step'leri var mı kontrol et
        if (step.TaskSteps.Any(ts => ts.IsActive))
            throw new Exception("Bu adımda aktif iş adımları var. Önce bunları taşıyın.");

        // Soft delete
        step.IsActive = false;
        step.UpdatedDate = DateTime.UtcNow;

        _context.Set<Step>().Update(step);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<IList<Step>> GetAllAsync(GetAllStepsQuery request, CancellationToken cancellationToken)
    {
        IQueryable<Step> query = _context.Set<Step>()
            .AsQueryable();

        // Arama filtresi
        if (!string.IsNullOrEmpty(request.Search))
        {
            string searchLower = request.Search.ToLower();
            query = query.Where(s =>
                s.Name.ToLower().Contains(searchLower) ||
                s.Code.ToLower().Contains(searchLower)
            );
        }

        // Aktiflik filtresi
        if (request.IsActive.HasValue)
        {
            query = query.Where(s => s.IsActive == request.IsActive.Value);
        }

        // Sayfalama
        var steps = await query
            .OrderBy(s => s.Code)
            .ThenBy(s => s.Name)
            .Skip((request.PageNumber - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToListAsync(cancellationToken);

        return steps;
    }

    public async Task<Step> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        Step? step = await _context.Set<Step>()
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);

        if (step is null)
            throw new Exception("İş adımı bulunamadı.");

        return step;
    }
}