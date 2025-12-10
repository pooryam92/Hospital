namespace Hospital.Domain;

public class Patient
{
    public Guid Id { get; private set; }
    public required string Name { get; set; }
    public required int Bsn { get; set; }
    public List<Medication> Medications { get; set; } = [];
}