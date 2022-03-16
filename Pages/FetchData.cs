using System.Net.Http.Json;
using BlazorApiClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorApiClient.Pages
{
    public partial class FetchData
    {
        [Inject]
        private HttpClient Http { get; set; }
        private LaunchDto[] launchDtos;
        protected override async Task OnInitializedAsync()
        {
            launchDtos = await Http.GetFromJsonAsync<LaunchDto[]>("/rest/launches/");
        }
    }
}