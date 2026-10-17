using HHAManagementSystem.Models;

namespace HHAManagementSystem.Repositories;

public interface ICaregiverRepository
{
    Task<List<Caregiver>> GetAllAsync();
    Task<Caregiver?> GetByIdAsync(int id);
    Task AddAsync(Caregiver caregiver);
    Task UpdateAsync(Caregiver caregiver);
    Task DeleteAsync(int id);
}
