using Hospital.Application.Abstractions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Hospital.Application.Record.Queries;

public record GetRecordFileQuery(int Bsn, string File) : IRequest<Stream?>; 

public class GetRecordFileQueryHandler(IHospitalContext context, IFileHandler fileHandler) : IRequestHandler<GetRecordFileQuery, Stream?>
{
    public async Task<Stream?> Handle(GetRecordFileQuery request, CancellationToken cancellationToken)
    {
        var record= await context.MedicalRecords
            .Include(p=>p.Patient)
            .SingleOrDefaultAsync(p => p.RecordName == request.File && p.Patient.Bsn == request.Bsn, cancellationToken);

        if (record == null)
        {
            return null;
        }
        
        return await fileHandler.GetFileAsync(record.RecordName);
    }
}