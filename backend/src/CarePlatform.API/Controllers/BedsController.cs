using Capacity.Application.Commands.CreateBed;
using Capacity.Application.Commands.OccupyBed;
using Capacity.Application.Commands.ReleaseBed;
using Microsoft.AspNetCore.Mvc;

namespace CarePlatform.API.Controllers;

[ApiController]
[Route("api/beds")]
public class BedsController : ControllerBase
{
    private readonly CreateBedCommandHandler _createHandler;
    private readonly OccupyBedCommandHandler _occupyHandler;
    private readonly ReleaseBedCommandHandler _releaseHandler;

    public BedsController(
        CreateBedCommandHandler createHandler,
        OccupyBedCommandHandler occupyHandler,
        ReleaseBedCommandHandler releaseHandler)
    {
        _createHandler = createHandler;
        _occupyHandler = occupyHandler;
        _releaseHandler = releaseHandler;
    }

    [HttpPost("{id}")]
    public async Task<IActionResult> Create(Guid id)
    {
        await _createHandler.Handle(new CreateBedCommand(id));
        return CreatedAtAction(nameof(Create), new { id }, null);
    }

    [HttpPost("{id}/occupy")]
    public async Task<IActionResult> Occupy(Guid id)
    {
        await _occupyHandler.Handle(new OccupyBedCommand(id));
        return Ok();
    }

    [HttpPost("{id}/release")]
    public async Task<IActionResult> Release(Guid id)
    {
        await _releaseHandler.Handle(new ReleaseBedCommand(id));
        return Ok();
    }
}
