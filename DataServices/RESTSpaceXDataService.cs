using System.Net.Http.Json;
using BlazorApiClient.Dtos;

namespace BlazorApiClient.DataServices
{

    public class RESTSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient _httpClient;
        public RESTSpaceXDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LaunchDto[]> GetAllLaunchesAsync() => await _httpClient.GetFromJsonAsync<LaunchDto[]>("/rest/launches");

    }
}