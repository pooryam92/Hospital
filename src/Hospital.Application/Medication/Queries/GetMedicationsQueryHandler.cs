using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Application.Medication.Queries;

public record GetMedicationsQuery(int Bsn) : IRequest<List<Domain.MedicationItem>>;

public class GetMedicationsQueryHandler(IHospitalContext context) : IRequestHandler<GetMedicationsQuery, List<Domain.MedicationItem>>
{
    public async Task<List<Domain.MedicationItem>> Handle(GetMedicationsQuery request, CancellationToken cancellationToken)
    {
        var patient = await context.Patients
            .Include(p=>p.Medications)
            .SingleOrDefaultAsync(p => p.Bsn == request.Bsn, cancellationToken);

        return patient?.Medications?? [];
    }
}
