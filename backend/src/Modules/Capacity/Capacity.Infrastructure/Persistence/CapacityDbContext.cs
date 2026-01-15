using Capacity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Capacity.Infrastructure.Persistence;

public class CapacityDbContext : DbContext
{
    public CapacityDbContext(DbContextOptions<CapacityDbContext> options)
        : base(options)
    {
    }

    public DbSet<Bed> Beds => Set<Bed>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("capacity");

        modelBuilder.Entity<Bed>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.Status)
                  .HasConversion<string>()
                  .IsRequired();
        });
    }
}
