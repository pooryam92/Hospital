using System.Net.Http.Json;
using Hospital.Features;

namespace Hospital.Api.Tests;

public class MedicationEndpointTests(HospitalApiFixture factory) : IClassFixture<HospitalApiFixture>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task MedicationEndpoint_returns_all_medications_for_patient()
    {
        //arrange 
        const int bsn = 123456789;
        
        //act
        var response = await _client.GetAsync($"/api/patient/{bsn}/medication");
        
        //assert
        response.EnsureSuccessStatusCode();
        var responseObject = await response.Content.ReadFromJsonAsync<List<MedicationResponse>>();
        Assert.Equal(2, responseObject?.Count);
    }
}