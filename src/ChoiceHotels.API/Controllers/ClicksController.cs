using ChoiceHotels.Application.UseCases.GetAllClicks;
using ChoiceHotels.Application.UseCases.TrackClick;
using ChoiceHotels.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ChoiceHotels.API.Controllers;

[ApiController]
public class ClicksController(TrackClickUseCase trackClickUseCase, GetAllClicksUseCase getAllClicksUseCase) : ControllerBase
{
    [HttpGet("click")]
    public async Task<IActionResult> TrackClick(
        [FromQuery] string offer,
        [FromQuery] string sub1)
    {
        var command = new TrackClickCommand(offer, sub1,
            HttpContext.Connection.RemoteIpAddress?.ToString() ?? string.Empty,
            Request.Headers["User-Agent"].ToString());

        try
        {
            TrackClickResult result = await trackClickUseCase.ExecuteAsync(command);
            return Redirect(result.RedirectUrl);
        }
        catch (KeyNotFoundException)
        {
            return NotFound(new { error = $"Brand '{offer}' not found" });
        }
    }

    [HttpGet("clicks")]
    public async Task<IActionResult> GetAllClicks()
    {
        List<Click> clicks = await getAllClicksUseCase.ExecuteAsync();
        return Ok(clicks);
    }
}