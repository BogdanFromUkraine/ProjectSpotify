using ProjectTrackingSpotify.Models;

namespace ProjectTrackingSpotify.Services.GetArtist
{
    public interface IGetArtist
    {
        Task<Artist> GetArtistById(string accessToken, string id);
    }
}
