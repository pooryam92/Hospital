using FastEndpoints;
using Hospital.Features.Shared;

namespace Hospital.Features;

public record MedicationRequest : BsnRequest;

public record MedicationResponse(string Name);