using Capacity.Application.Interfaces;
using Capacity.Domain.Entities;
using Capacity.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Capacity.Infrastructure.Repositories;

public class BedRepository : IBedRepository
{
    private readonly CapacityDbContext _context;

    public BedRepository(CapacityDbContext context)
    {
        _context = context;
    }

    public async Task<Bed?> GetByIdAsync(Guid id)
    {
        return await _context.Beds.FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task AddAsync(Bed bed)
    {
        await _context.Beds.AddAsync(bed);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
