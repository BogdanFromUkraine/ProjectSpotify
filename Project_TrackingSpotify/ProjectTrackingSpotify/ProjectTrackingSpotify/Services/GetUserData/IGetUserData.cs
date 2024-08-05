using ProjectTrackingSpotify.Models;

namespace ProjectTrackingSpotify.Services.GetUserData
{
    public interface IGetUserData
    {
        Task<UserData> GetUserDataFunc(string accessToken);
    }
}
