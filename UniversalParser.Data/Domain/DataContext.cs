using Microsoft.EntityFrameworkCore;
using UniversalParser.Data.Entities;

namespace UniversalParser.Data.Domain;

public class DataContext(DbContextOptions<DataContext> options)
    : DbContext(options)
{
    public DbSet<Trip> Trips { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Trip>()
            .HasIndex(t => t.PULocationID)
            .HasDatabaseName("IX_Trips_PULocationID");

        modelBuilder.Entity<Trip>()
            .HasIndex(t => t.TripDistance)
            .HasDatabaseName("IX_Trips_TripDistance");

        modelBuilder.Entity<Trip>()
            .HasIndex(t => new { t.TpepPickupDatetime, t.TpepDropoffDatetime })
            .HasDatabaseName("IX_Trips_TripDuration");
    }
}