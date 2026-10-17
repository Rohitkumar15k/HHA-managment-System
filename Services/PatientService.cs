using AutoMapper;
using HHAManagementSystem.DTOs;
using HHAManagementSystem.Models;
using HHAManagementSystem.Repositories;

namespace HHAManagementSystem.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _repository;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<PatientDto>> GetAllAsync() =>
        _mapper.Map<List<PatientDto>>(await _repository.GetAllAsync());

    public async Task<PatientDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<PatientDto>(entity);
    }

    public async Task SaveAsync(PatientDto dto)
    {
        var entity = _mapper.Map<Patient>(dto);
        if (dto.Id == 0) await _repository.AddAsync(entity);
        else await _repository.UpdateAsync(entity);
    }

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}
