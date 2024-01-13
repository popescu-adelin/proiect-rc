using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace serverPontaj.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EspController : ControllerBase
{
    private readonly IClockingService _clockingService;

    public EspController(IClockingService clockingService)
    {
        _clockingService = clockingService;
    }

    [HttpPost(Name = "addPontaj/{cardId}")]
    public async Task<IActionResult> AddClocking(string cardId)
    {
        await _clockingService.ProcessClocking(cardId);
        return Ok();
    }
}
