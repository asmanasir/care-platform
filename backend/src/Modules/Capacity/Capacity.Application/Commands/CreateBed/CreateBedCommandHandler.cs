using Capacity.Application.Interfaces;
using Capacity.Domain.Entities;

namespace Capacity.Application.Commands.CreateBed;

public class CreateBedCommandHandler
{
    private readonly IBedRepository _repository;

    public CreateBedCommandHandler(IBedRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateBedCommand command)
    {
        var existing = await _repository.GetByIdAsync(command.BedId);
        if (existing != null)
            throw new InvalidOperationException("Bed already exists.");

        var bed = new Bed(command.BedId);

        await _repository.AddAsync(bed);
        await _repository.SaveChangesAsync();
    }
}
