using FastEndpoints;
using Hospital.Domain;

namespace Hospital.Features;

public class MedicationMapper : Mapper<MedicationRequest, MedicationResponse , Medication>
{
    public override MedicationResponse FromEntity(Medication e)
    {
        return new MedicationResponse(e.Name);
    }
}