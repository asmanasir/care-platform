using Capacity.Domain.Entities;

namespace Capacity.Application.Interfaces;

public interface IBedRepository
{
    Task<Bed?> GetByIdAsync(Guid id);
    Task AddAsync(Bed bed);
    Task SaveChangesAsync();
}
