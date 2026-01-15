using Capacity.Application.Commands.OccupyBed;
using Microsoft.AspNetCore.Mvc;

namespace CarePlatform.API.Controllers;

[ApiController]
[Route("api/beds")]
public class BedsController : ControllerBase
{
    private readonly OccupyBedCommandHandler _handler;

    public BedsController(OccupyBedCommandHandler handler)
    {
        _handler = handler;
    }

    [HttpPost("{id}/occupy")]
    public async Task<IActionResult> Occupy(Guid id)
    {
        await _handler.Handle(new OccupyBedCommand(id));
        return Ok();
    }
}
