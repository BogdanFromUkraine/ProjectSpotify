using Azure.Core;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using Microsoft.Owin;
using System.Text.Json;
using ProjectTrackingSpotify.Models;

namespace ProjectTrackingSpotify.Services.GetUserData
{
    public class GetUserData : IGetUserData
    {
        private readonly HttpClient _httpClient;

        public GetUserData(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<UserData> GetUserDataFunc(string accessToken)
        {

            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.GetAsync("https://api.spotify.com/v1/me");


                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var responseObject = await JsonSerializer.DeserializeAsync<UserData>(responseStream);

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
