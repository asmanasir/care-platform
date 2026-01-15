using Capacity.Domain.Enums;

namespace Capacity.Domain.Entities;

public class Bed
{
    public Guid Id { get; private set; }
    public BedStatus Status { get; private set; }

    private Bed() { } // Required by ORM

    public Bed(Guid id)
    {
        Id = id;
        Status = BedStatus.Available;
    }

    public void Occupy()
    {
        if (Status == BedStatus.Occupied)
            throw new InvalidOperationException("Bed is already occupied.");

        Status = BedStatus.Occupied;
    }

    public void Release()
    {
        if (Status == BedStatus.Available)
            throw new InvalidOperationException("Bed is already available.");

        Status = BedStatus.Available;
    }
}
