using ProjectTrackingSpotify.Models;

namespace ProjectTrackingSpotify.Services
{
	public interface ISpotifyAccountService
	{
        public string GenerateOAuthSpotify(string scope, string redirectUrl, string codeChallange, string codeVerifier);

        public Task<TokenResult> ExchangeCodeToken(string code, string codeVerifier, string redirectUrl);

        public Task<string> RefreshToken(string refreshToken, int? exchangeCodeTokenId); 

    }
}
