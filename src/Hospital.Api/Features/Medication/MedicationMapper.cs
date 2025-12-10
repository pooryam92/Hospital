using FastEndpoints;
using Hospital.Domain;

namespace Hospital.Features;

public class MedicationMapper : Mapper<MedicationRequest, MedicationResponse , MedicationItem>
{
    public override MedicationResponse FromEntity(MedicationItem e)
    {
        return new MedicationResponse(e.Name);
    }
}