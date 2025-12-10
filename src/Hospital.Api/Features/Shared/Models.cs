using FastEndpoints;

namespace Hospital.Features.Shared;

public abstract record BsnRequest
{
    [RouteParam]   
    public int Bsn { get; set; } 
}