namespace Hospital.Domain;

public class MedicationItem
{
    public Guid Id { get; private set; }
    public required string Name { get; set; }
    public Patient Patient { get; set; }
    public Guid PatientId { get; set; }
}
