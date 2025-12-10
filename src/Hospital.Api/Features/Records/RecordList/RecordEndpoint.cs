using FastEndpoints;
using Hospital.Application.Record.Queries;
using MediatR;

namespace Hospital.Features.Records;

public class RecordEndpoint(ISender sender, ILogger<RecordEndpoint> logger) : Endpoint<RecordRequest,List<RecordResponse>,RecordMapper>
{
    public override void Configure()
    {
        Get("api/patient/{bsn:int}/records");
        Tags("patient");
        AllowAnonymous();
    }

    public override async Task HandleAsync(RecordRequest req, CancellationToken ct)
    {
        logger.LogInformation("Getting records list  for patient {bsn}", req.Bsn);
        var medication = await sender.Send(new GetRecordsQuery(req.Bsn), ct);
        var response = medication.Select(p=> Map.FromEntity(p)).ToList();
        await Send.OkAsync(response, ct);
    }
}

