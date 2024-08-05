using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Owin;
using ProjectTrackingSpotify.DataAccess.Repository.IRepository;
using ProjectTrackingSpotify.Models;
using ProjectTrackingSpotify.Services;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using static System.Formats.Asn1.AsnWriter;

namespace ProjectTrackingSpotify.Services
{
    public class SpotifyAccountService : ISpotifyAccountService
    {
        private readonly HttpClient _httpClient;
        private readonly ITokenResultRepository _tokenResult; // використовую tokenResult
        private readonly ILogger<SpotifyAccountService> _logger;
        private readonly ITokenResultRepository _tokenResultRepository;
        private readonly IUrlSpotifyRepository _urlSpotifyRepository;
        
        public SpotifyAccountService(HttpClient httpClient,
            ITokenResultRepository tokenResult,
            ILogger<SpotifyAccountService> logger,
            ITokenResultRepository tokenResultRepository,
            IUrlSpotifyRepository urlSpotifyRepository)
        {
            _httpClient = httpClient;
            _tokenResult = tokenResult;
            _logger = logger;
            _tokenResultRepository = tokenResultRepository;
            _urlSpotifyRepository = urlSpotifyRepository;

        }
        string ClientId = "92eb1a8479764fa3ba9c995e44473d9e";
         
        public string GenerateOAuthSpotify(string scope, string redirectUrl, string codeChallange, string codeVerifier)
        {
            string oAuthServerEndpoint = "https://accounts.spotify.com/authorize";

            var queryParams = new Dictionary<string, string>()
            {
                { "client_id", ClientId},
                { "redirect_uri", redirectUrl},
                { "response_type", "code" },
                { "scope", scope },
                { "code_challenge", codeChallange},
                {"code_challenge_method", "S256"},

            };

            //об'єднюю query параметри з endpoint
            var url = QueryHelpers.AddQueryString(oAuthServerEndpoint, queryParams);

            UrlSpotify urlSpotify = new UrlSpotify();
            urlSpotify.Url = url;
            urlSpotify.Challenge = codeChallange;
            urlSpotify.Verifier = codeVerifier; 

            _urlSpotifyRepository.Add(urlSpotify);
            _urlSpotifyRepository.Save();
            return url;
        }

        public async Task<TokenResult> ExchangeCodeToken(string code, string codeVerifier, string redirectUrl)
        {

            string ClientId = "92eb1a8479764fa3ba9c995e44473d9e";
            

            var parameters = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", ClientId), 
            new KeyValuePair<string, string>("grant_type", "authorization_code"),
            new KeyValuePair<string, string>("code", code),
            new KeyValuePair<string, string>("redirect_uri", redirectUrl), 
            new KeyValuePair<string, string>("code_verifier", codeVerifier)
        });
            HttpClient client = new HttpClient();
            

            // Виконати POST-запит на обмін коду на токен
            var response = await client.PostAsync("https://accounts.spotify.com/api/token", parameters);

            using var responseStream = await response.Content.ReadAsStreamAsync();
            //Deserialise the response into an object (see AuthResult class), because we haven't built the AuthResult object 
            //this will show as a red underline error!
            var authResult = await JsonSerializer.DeserializeAsync<TokenResult>(responseStream);

            //код, який призначений для зберігання даних у бд
              _tokenResult.Add(authResult);
              await _tokenResult.Save();

            //Return the deserialised result
            return authResult;

        }

        public async Task<string> RefreshToken(string refreshToken, int? exchangeCodeTokenId)
        {
         
            string ClientId = "92eb1a8479764fa3ba9c995e44473d9e";
            var parameters = new FormUrlEncodedContent(new[] 
            {
                new KeyValuePair<string, string>("grant_type", "refresh_token"),
                new KeyValuePair<string, string>("refresh_token", refreshToken),
                new KeyValuePair<string, string>("client_id", ClientId),
            });
            HttpClient client = new HttpClient();


            // Виконати POST-запит на обмін коду на токен
            var response = await client.PostAsync("https://accounts.spotify.com/api/token", parameters);

            using var responseStream = await response.Content.ReadAsStreamAsync();
            //Deserialise the response into an object (see AuthResult class), because we haven't built the AuthResult object 
            //this will show as a red underline error!
            var authResult = await JsonSerializer.DeserializeAsync<TokenResult>(responseStream);


            //код, який призначений для оновлення даних у бд

            //отримую існуючий код
            TokenResult tokenFromDb = _tokenResultRepository.Get(u => u.Id == exchangeCodeTokenId);

            //заміна значень
            tokenFromDb.AccessToken = authResult.AccessToken;
            tokenFromDb.ExpiresIn = authResult.ExpiresIn;
            tokenFromDb.Scope = authResult.Scope;
            tokenFromDb.TokenType = authResult.TokenType;
            tokenFromDb.RefreshToken = authResult.RefreshToken;

            //оновлення значень та збереження
            await _tokenResult.Update(tokenFromDb);
            await _tokenResult.Save();


            //Return the deserialised result
            return null;
        }
    }
}
