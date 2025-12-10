using FastEndpoints;
using Hospital.Application.Medication.Queries;
using MediatR;

namespace Hospital.Features;

public class MedicationEndpoint(ISender sender, ILogger<MedicationEndpoint> logger) 
    : Endpoint<MedicationRequest, List<MedicationResponse>, MedicationMapper>
{
    public override void Configure()
    {
        Get("api/patient/{bsn:int}/medication");
        Tags("patient");
        AllowAnonymous();
    }

    public override async Task HandleAsync(MedicationRequest req, CancellationToken ct)
    {
        logger.LogInformation("Getting medications for patient {bsn}", req.Bsn);
        var medication = await sender.Send(new GetMedicationsQuery(req.Bsn), ct);
        var response = medication.Select(p=> Map.FromEntity(p)).ToList();
        await Send.OkAsync(response, ct);
    }
}