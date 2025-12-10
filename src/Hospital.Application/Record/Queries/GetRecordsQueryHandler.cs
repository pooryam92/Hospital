using Hospital.Application.Medication.Queries;
using Hospital.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Application.Record.Queries;

public record GetRecordsQuery(int Bsn) : IRequest<List<MedicalRecord>>; 

public class GetRecordsQueryHandler(IHospitalContext context) : IRequestHandler<GetRecordsQuery, List<MedicalRecord>>
{
    public async Task<List<MedicalRecord>> Handle(GetRecordsQuery request, CancellationToken cancellationToken)
    {
        var patient = await context.Patients    
            .Include(p=>p.MedicalRecords)
            .SingleOrDefaultAsync(p => p.Bsn == request.Bsn, cancellationToken);

        return patient?.MedicalRecords?? [];
    }
}
