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

        var medications = new List<Medication>
        {
            new Medication()
            {
                Name = "Aspirin"
            },
            new Medication()
            {
                Name = "Ibuprofen"
            }
        };

        var patients = new List<Patient>
        {
            new Patient()
            {
                Name = "John",
                Bsn = 123456789,
                Medications = medications
            }
        };

        await context.Patients.AddRangeAsync(patients);
        await context.SaveChangesAsync();

        logger.LogInformation("Seeding completed.");
    }
}