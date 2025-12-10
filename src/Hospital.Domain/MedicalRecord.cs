namespace Hospital.Domain;

public class MedicalRecord
{
   public Guid Id { get; private set; }
   public required string RecordName { get; set; }
   public Patient Patient { get; set; }
   public Guid PatientId { get; set; }
}