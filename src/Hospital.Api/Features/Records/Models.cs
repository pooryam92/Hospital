using Hospital.Features.Shared;

namespace Hospital.Features.Records;

public record RecordRequest : BsnRequest;
public record RecordResponse(string RecordName);