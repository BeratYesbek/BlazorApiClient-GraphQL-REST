using BlazorApiClient.Dtos;

namespace BlazorApiClient.DataServices
{
    public interface ISpaceXDataService
    {
        Task<LaunchDto[]> GetAllLaunchesAsync();
    }
    
}