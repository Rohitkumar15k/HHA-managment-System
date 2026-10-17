using HHAManagementSystem.Data;
using HHAManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HHAManagementSystem.Repositories;

public class CaregiverRepository : ICaregiverRepository
{
    private readonly AppDbContext _context;

    public CaregiverRepository(AppDbContext context) => _context = context;

    public Task<List<Caregiver>> GetAllAsync() =>
        _context.Caregivers.AsNoTracking().OrderBy(x => x.LastName).ToListAsync();

    public Task<Caregiver?> GetByIdAsync(int id) =>
        _context.Caregivers.FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Caregiver caregiver)
    {
        _context.Caregivers.Add(caregiver);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Caregiver caregiver)
    {
        _context.Caregivers.Update(caregiver);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.Caregivers.FindAsync(id);
        if (item is not null)
        {
            _context.Caregivers.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
