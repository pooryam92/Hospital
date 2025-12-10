using Hospital.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Application;

public interface IHospitalContext
{
    DbSet<Patient> Patients{ get; }
    DbSet<Domain.Medication> Medications{ get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}