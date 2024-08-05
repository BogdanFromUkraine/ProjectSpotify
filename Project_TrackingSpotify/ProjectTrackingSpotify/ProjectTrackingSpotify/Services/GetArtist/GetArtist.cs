using Azure.Core;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.Owin;
using System.Text.Json;
using ProjectTrackingSpotify.Models;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTrackingSpotify.Services.GetArtist
{
    public class GetArtist : IGetArtist
    {
        private readonly HttpClient _httpClient;
        public GetArtist(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
        public async Task<Artist> GetArtistById(string accessToken, string id )
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.GetAsync($"https://api.spotify.com/v1/artists/{id}");


                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var responseObject = await JsonSerializer.DeserializeAsync<Artist>(responseStream);

                return responseObject;


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }
    }
}
