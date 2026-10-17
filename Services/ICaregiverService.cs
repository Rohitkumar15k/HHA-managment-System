using HHAManagementSystem.DTOs;

namespace HHAManagementSystem.Services;

public interface ICaregiverService
{
    Task<List<CaregiverDto>> GetAllAsync();
    Task<CaregiverDto?> GetByIdAsync(int id);
    Task SaveAsync(CaregiverDto dto);
    Task DeleteAsync(int id);
}
