using ChoiceHotels.Application.Interfaces;
using ChoiceHotels.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChoiceHotels.Infrastructure.Postgres;

public class ClickRepository(ClickContext context) : IClickRepository
{
    private readonly ClickContext _context = context;

    public async Task AddAsync(Click click)
    {
        await _context.Clicks.AddAsync(click);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<Click>> GetAllAsync()
    {
        return await _context.Clicks.AsNoTracking().ToListAsync();
    }
}