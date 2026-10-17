using HHAManagementSystem.Data;
using HHAManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HHAManagementSystem.Repositories;

public class VisitRepository : IVisitRepository
{
    private readonly AppDbContext _context;

    public VisitRepository(AppDbContext context) => _context = context;

    public Task<List<Visit>> GetAllAsync() =>
        _context.Visits.Include(x => x.Caregiver).Include(x => x.Patient)
            .AsNoTracking().OrderBy(x => x.VisitDate).ToListAsync();

    public Task<Visit?> GetByIdAsync(int id) =>
        _context.Visits.Include(x => x.Caregiver).Include(x => x.Patient)
            .FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Visit visit)
    {
        _context.Visits.Add(visit);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Visit visit)
    {
        _context.Visits.Update(visit);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.Visits.FindAsync(id);
        if (item is not null)
        {
            _context.Visits.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
