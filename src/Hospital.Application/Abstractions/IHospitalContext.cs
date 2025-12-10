using Hospital.Domain;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Application;

public interface IHospitalContext
{
    DbSet<Patient> Patients{ get; }
    DbSet<MedicationItem> Medications{ get; }
    DbSet<MedicalRecord> MedicalRecords{ get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}