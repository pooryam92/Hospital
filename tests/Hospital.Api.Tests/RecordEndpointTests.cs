using System.Net.Http.Json;
using Hospital.Features.Records;

namespace Hospital.Api.Tests;
public class RecordEndpointTests(HospitalApiFixture factory) : IClassFixture<HospitalApiFixture>
{
    private readonly HttpClient _client = factory.CreateClient();

    [Fact]
    public async Task RecordEndpoint_returns_all_records_for_patient()
    {
        //arrange 
        const int bsn = 123456789;
        
        //act
        var response = await _client.GetAsync($"/api/patient/{bsn}/records");
        
        //assert
        response.EnsureSuccessStatusCode();
        var responseObject = await response.Content.ReadFromJsonAsync<List<RecordResponse>>();
        Assert.Equal(2, responseObject?.Count);
    }
}
