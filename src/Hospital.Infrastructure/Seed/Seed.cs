using Hospital.Domain;
using Hospital.Infrastructure.Database;
using Microsoft.Extensions.Logging;

namespace Hospital.Infrastructure.Seed;

public class Seed(HospitalContext context, ILogger<Seed> logger)
{
    public async Task SeedDataAsync()
    {
        if (context.Patients.Any())
            return;

        logger.LogInformation("Seeding data...");

        var medications = new List<MedicationItem>
        {
            new ()
            {
                Name = "Aspirin"
            },
            new ()
            {
                Name = "Ibuprofen"
            }
        };

        var records = new List<MedicalRecord>()
        {
            new()
            {
                RecordName = "uitslag.pdf"
            },
            new()
            {
                RecordName = "test.zip"
            }
        };

        var patients = new List<Patient>
        {
            new ()
            {
                Name = "John",
                Bsn = 123456789,
                Medications = medications,
                MedicalRecords = records
            }
        };

        await context.Patients.AddRangeAsync(patients);
        await context.SaveChangesAsync();

        logger.LogInformation("Seeding completed.");
    }
}