using ChoiceHotels.Application.Interfaces;
using ChoiceHotels.Domain.Entities;

namespace ChoiceHotels.Application.UseCases.GetAllClicks;

public class GetAllClicksUseCase
{
    private readonly IClickRepository _clickRepository;

    public GetAllClicksUseCase(IClickRepository clickRepository)
    {
        _clickRepository = clickRepository;
    }

    public async Task<List<Click>> ExecuteAsync()
    {
        return await _clickRepository.GetAllAsync();
    }
}