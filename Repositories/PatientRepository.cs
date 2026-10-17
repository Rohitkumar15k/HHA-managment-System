using HHAManagementSystem.Data;
using HHAManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HHAManagementSystem.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly AppDbContext _context;

    public PatientRepository(AppDbContext context) => _context = context;

    public Task<List<Patient>> GetAllAsync() =>
        _context.Patients.AsNoTracking().OrderBy(x => x.LastName).ToListAsync();

    public Task<Patient?> GetByIdAsync(int id) =>
        _context.Patients.FirstOrDefaultAsync(x => x.Id == id);

    public async Task AddAsync(Patient patient)
    {
        _context.Patients.Add(patient);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Patient patient)
    {
        _context.Patients.Update(patient);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var item = await _context.Patients.FindAsync(id);
        if (item is not null)
        {
            _context.Patients.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
