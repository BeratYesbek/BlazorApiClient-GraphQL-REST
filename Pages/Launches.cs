using BlazorApiClient.DataServices;
using BlazorApiClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorApiClient.Pages
{
    public partial class Launches
    {
        private LaunchDto[]? launchDtos;

        [Inject]
        private ISpaceXDataService? SpaceXDataService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            launchDtos = await SpaceXDataService!.GetAllLaunchesAsync();
        }

    }
}