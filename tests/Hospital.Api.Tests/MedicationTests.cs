namespace Hospital.Api.Tests;

public class MedicationTests(HospitalApiFixture factory) : IClassFixture<HospitalApiFixture>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task Test1()
    {
        var response = await _client.GetAsync("/api/patient/1/medication");
        response.EnsureSuccessStatusCode();
    }
}