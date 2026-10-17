using HHAManagementSystem.DTOs;

namespace HHAManagementSystem.Services;

public interface IPatientService
{
    Task<List<PatientDto>> GetAllAsync();
    Task<PatientDto?> GetByIdAsync(int id);
    Task SaveAsync(PatientDto dto);
    Task DeleteAsync(int id);
}
