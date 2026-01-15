using Capacity.Application.Interfaces;

namespace Capacity.Application.Commands.OccupyBed;

public class OccupyBedCommandHandler
{
    private readonly IBedRepository _repository;

    public OccupyBedCommandHandler(IBedRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(OccupyBedCommand command)
    {
        var bed = await _repository.GetByIdAsync(command.BedId)
          ?? throw new InvalidOperationException("Bed not found.");

        bed.Occupy();

        await _repository.SaveChangesAsync();
    }
}
