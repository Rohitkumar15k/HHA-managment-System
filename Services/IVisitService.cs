using HHAManagementSystem.DTOs;

namespace HHAManagementSystem.Services;

public interface IVisitService
{
    Task<List<VisitDto>> GetAllAsync();
    Task<VisitDto?> GetByIdAsync(int id);
    Task SaveAsync(VisitDto dto);
    Task DeleteAsync(int id);
}
