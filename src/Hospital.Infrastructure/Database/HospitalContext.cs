using Hospital.Application;
using Hospital.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Infrastructure.Database;

public class HospitalContext(DbContextOptions<HospitalContext> options) : DbContext (options), IHospitalContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Medication> Medications { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasMany(x => x.Medications)
                .WithOne(x => x.Patient);
        });
        
        modelBuilder.Entity<Medication>(entity =>
        {
            entity.HasKey(x => x.Id);
        });
    }
}