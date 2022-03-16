using System.Text;
using System.Text.Json;
using BlazorApiClient.Dtos;

namespace BlazorApiClient.DataServices
{
    public class GraphQLSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient _httpClient;

        public GraphQLSpaceXDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<LaunchDto[]?> GetAllLaunchesAsync()
        {
            var queryObject = new
            {
                query = @"
                    query {
                        launches {
                            id
                            is_tentative
                            launch_date_local
                            mission_name
                        }
                    }
                ",
                variables = new { }
            };

            var launchQuery = new StringContent(
                JsonSerializer.Serialize(queryObject),
                Encoding.UTF8,
                "application/json"
            );

            var responnse = await _httpClient.PostAsync("/graphql/",launchQuery);
            if(responnse.IsSuccessStatusCode)
            {
               var gqlData =  await JsonSerializer.DeserializeAsync<GqlData>
                (await responnse.Content.ReadAsStreamAsync());
                return gqlData.Data.Launches;
                
            }
            return null;
        }
    }
}