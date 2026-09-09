using ChoiceHotels.Domain.Entities;

namespace ChoiceHotels.Application.Interfaces;

public interface IClickRepository
{
    Task AddAsync(Click click);
    Task SaveChangesAsync();
    Task<List<Click>> GetAllAsync();
}