using AutoMapper;
using HHAManagementSystem.DTOs;
using HHAManagementSystem.Models;
using HHAManagementSystem.Repositories;

namespace HHAManagementSystem.Services;

public class CaregiverService : ICaregiverService
{
    private readonly ICaregiverRepository _repository;
    private readonly IMapper _mapper;

    public CaregiverService(ICaregiverRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<CaregiverDto>> GetAllAsync() =>
        _mapper.Map<List<CaregiverDto>>(await _repository.GetAllAsync());

    public async Task<CaregiverDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<CaregiverDto>(entity);
    }

    public async Task SaveAsync(CaregiverDto dto)
    {
        var entity = _mapper.Map<Caregiver>(dto);
        if (dto.Id == 0) await _repository.AddAsync(entity);
        else await _repository.UpdateAsync(entity);
    }

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}
