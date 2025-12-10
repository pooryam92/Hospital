using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Application.Medication.Queries;

public record GetMedicationsQuery(int Bsn) : IRequest<List<Domain.Medication>>
{
    public int Bsn { get; init; } = Bsn;
};

public class GetMedicationsQueryHandler(IHospitalContext context) : IRequestHandler<GetMedicationsQuery, List<Domain.Medication>>
{
    public async Task<List<Domain.Medication>> Handle(GetMedicationsQuery request, CancellationToken cancellationToken)
    {
        var patient = await context.Patients
            .Include(p=>p.Medications)
            .SingleOrDefaultAsync(p => p.Bsn == request.Bsn, cancellationToken: cancellationToken);

        return patient?.Medications?? [];
    }
}
