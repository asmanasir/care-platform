using CarePlatform.BuildingBlocks.Domain;
using Capacity.Domain.Enums;

namespace Capacity.Domain.Entities;

public class Bed : Entity
{
    public BedStatus Status { get; private set; }

    private Bed() { } // For EF Core

    public Bed(Guid id) : base(id)
    {
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
