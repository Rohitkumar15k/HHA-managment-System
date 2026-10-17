using HHAManagementSystem.Models;

namespace HHAManagementSystem.Repositories;

public interface IVisitRepository
{
    Task<List<Visit>> GetAllAsync();
    Task<Visit?> GetByIdAsync(int id);
    Task AddAsync(Visit visit);
    Task UpdateAsync(Visit visit);
    Task DeleteAsync(int id);
}
