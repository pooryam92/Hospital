namespace Hospital.Domain;

public class Patient
{
    public Guid Id { get; private set; }
    public required string Name { get; set; }
    public required int Bsn { get; set; }
    public List<MedicationItem> Medications { get; set; } = [];
    public List<MedicalRecord> MedicalRecords { get; set; } = [];
}