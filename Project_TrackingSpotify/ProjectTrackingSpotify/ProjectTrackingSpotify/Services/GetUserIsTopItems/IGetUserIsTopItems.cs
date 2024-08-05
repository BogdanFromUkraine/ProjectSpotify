using ProjectTrackingSpotify.Models;
using System.Collections;

namespace ProjectTrackingSpotify.Services.GetUserIsTopItems
{
    public interface IGetUserIsTopItems
    {
        Task<Item[]> GetTopItems(string type, int limit, string accessToken);
    }
}
