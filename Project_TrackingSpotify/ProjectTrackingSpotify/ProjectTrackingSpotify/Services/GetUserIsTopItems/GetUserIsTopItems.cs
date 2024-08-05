using NetTopologySuite.Index.HPRtree;
using ProjectTrackingSpotify.DataAccess.Repository.IRepository;
using ProjectTrackingSpotify.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace ProjectTrackingSpotify.Services.GetUserIsTopItems
{
    public class GetUserIsTopItems : IGetUserIsTopItems
    {
        private readonly HttpClient _httpClient;
        private readonly ITopItemsRepository _topItemsRepository;
        public GetUserIsTopItems(HttpClient httpClient, ITopItemsRepository topItemsRepository)
        {
            _httpClient = httpClient;
            _topItemsRepository = topItemsRepository;

        }
        public async Task<Item[]> GetTopItems(string type, int limit, string accessToken)
        {

            try
            {

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.GetAsync($"me/top/tracks?limit=5");


                response.EnsureSuccessStatusCode(); 

                using var responseStream = await response.Content.ReadAsStreamAsync();
                var responseObject = await JsonSerializer.DeserializeAsync<TopItems>(responseStream);

                return responseObject.items;
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return null;
        }
    }
}
