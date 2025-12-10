using FastEndpoints;
using Hospital.Application.Record.Queries;
using Hospital.Features.Shared;
using MediatR;

namespace Hospital.Features.Records.DownloadRecord;

public class DownloadRecord(ISender sender, ILogger<DownloadRecord> logger) : Endpoint<DownloadRecordRequest>
{
    public override void Configure()
    {
        Get("api/patient/{bsn:int}/record/{file}");
        Tags("patient");
        AllowAnonymous();
    }

    public override async Task HandleAsync(DownloadRecordRequest req, CancellationToken ct)
    {
        logger.LogInformation("Getting record {record} for patient {bsn}", req.File, req.Bsn);
        var record= await sender.Send(new GetRecordFileQuery(req.Bsn, req.File), ct);
        
        if (record == null)
        {
            await Send.NotFoundAsync(ct);
        }
        
        await Send.StreamAsync(record, cancellation: ct);
    }
}

public record DownloadRecordRequest : BsnRequest
{
    [RouteParam]
    public string File { get; set; }
}

