using Capacity.Application.Interfaces;

namespace Capacity.Application.Commands.ReleaseBed;

public class ReleaseBedCommandHandler
{
    private readonly IBedRepository _repository;

    public ReleaseBedCommandHandler(IBedRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(ReleaseBedCommand command)
    {
        var bed = await _repository.GetByIdAsync(command.BedId)
                  ?? throw new InvalidOperationException("Bed not found.");

        bed.Release();

        await _repository.SaveChangesAsync();
    }
}
