using FastEndpoints;
using Hospital.Domain;

namespace Hospital.Features.Records;

public class RecordMapper : Mapper<RecordRequest, RecordResponse, MedicalRecord>
{
    public override RecordResponse FromEntity(MedicalRecord e)
    {
        return new RecordResponse(e.RecordName);
    }
}