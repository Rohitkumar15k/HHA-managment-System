using AutoMapper;
using HHAManagementSystem.DTOs;
using HHAManagementSystem.Models;
using HHAManagementSystem.Repositories;

namespace HHAManagementSystem.Services;

public class VisitService : IVisitService
{
    private readonly IVisitRepository _repository;
    private readonly IMapper _mapper;

    public VisitService(IVisitRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<VisitDto>> GetAllAsync() =>
        _mapper.Map<List<VisitDto>>(await _repository.GetAllAsync());

    public async Task<VisitDto?> GetByIdAsync(int id)
    {
        var entity = await _repository.GetByIdAsync(id);
        return entity == null ? null : _mapper.Map<VisitDto>(entity);
    }

    public async Task SaveAsync(VisitDto dto)
    {
        var entity = _mapper.Map<Visit>(dto);
        if (dto.Id == 0) await _repository.AddAsync(entity);
        else await _repository.UpdateAsync(entity);
    }

    public Task DeleteAsync(int id) => _repository.DeleteAsync(id);
}
