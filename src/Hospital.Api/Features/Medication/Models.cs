using FastEndpoints;

namespace Hospital.Features;

public record MedicationRequest
{
    [RouteParam]   
    public int Bsn { get; set; } 
}

public record MedicationResponse(string Name);