using ChoiceHotels.Application.Interfaces;
using ChoiceHotels.Application.UseCases.TrackClick;
using ChoiceHotels.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace ChoiceHotels.Application.UseCases.TrackClick;

public class TrackClickUseCase
{
    private readonly IClickRepository _clickRepository;
    private readonly IConfiguration _configuration;

    public TrackClickUseCase(IClickRepository clickRepository, IConfiguration configuration)
    {
        _clickRepository = clickRepository;
        _configuration = configuration;
    }

    public async Task<TrackClickResult> ExecuteAsync(TrackClickCommand command)
    {
        var brandUrls = _configuration.GetSection("BrandUrls").Get<Dictionary<string, string>>();
        if (brandUrls == null || !brandUrls.TryGetValue(command.Offer, out var redirectUrl))
        {
            throw new KeyNotFoundException($"Brand '{command.Offer}' not found");
        }

        var click = new Click
        {
            Id = Guid.NewGuid(),
            ClickId = Guid.NewGuid().ToString(),
            Offer = command.Offer,
            Sub1 = command.Sub1,
            Timestamp = DateTime.UtcNow,
            Ip = command.Ip,
            UserAgent = command.UserAgent
        };

        await _clickRepository.AddAsync(click);
        await _clickRepository.SaveChangesAsync();

        return new TrackClickResult(click.ClickId, redirectUrl);
    }
}