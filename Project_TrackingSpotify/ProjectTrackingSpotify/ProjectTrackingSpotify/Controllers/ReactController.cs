using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectTrackingSpotify.DataAccess.Repository.IRepository;
using ProjectTrackingSpotify.Models;
using ProjectTrackingSpotify.Services;
using ProjectTrackingSpotify.Services.GetArtist;
using ProjectTrackingSpotify.Services.GetUserData;
using ProjectTrackingSpotify.Services.GetUserIsTopItems;
using ProjectTrackingSpotify.Utility;
using RTools_NTS.Util;
using System.Runtime.CompilerServices;

namespace ProjectTrackingSpotify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ReactController : ControllerBase
    {
        private readonly IGetUserIsTopItems _getUsersItem;
        private readonly ITokenResultRepository _tokenResultRepository;
        private readonly IUrlSpotifyRepository _urlSpotifyRepository;
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly IGetUserData _getUserData;
        private readonly IGetArtist _getArtist;
        
      
      
        public ReactController(IGetUserIsTopItems getUsersItem,
            ITokenResultRepository tokenResultRepository,
            IUrlSpotifyRepository urlSpotifyRepository,
            ISpotifyAccountService spotifyAccountService,
            IGetUserData getUserData,
            IGetArtist getArtist
            )
        {
            _getUsersItem = getUsersItem;
            _tokenResultRepository = tokenResultRepository;
            _urlSpotifyRepository = urlSpotifyRepository;
            _spotifyAccountService = spotifyAccountService;
            _getUserData = getUserData;
            _getArtist = getArtist;
      


        }

        [HttpGet]
        [EnableCors]
        public async Task<IActionResult> Get()
        {
            //я отримав всі токени та за допомогою LINQ передаю останній токен
            var Alltoken = _tokenResultRepository.GetAll();
            var token = Alltoken.Last();

            var result = await _getUsersItem.GetTopItems("tracks", 10, token.AccessToken);
            return Ok(result);
        }

        [HttpGet("Auth")]
        public  IActionResult AuthScreen()
        {


            //генерація pkce коду
            var (challenge, verifier) = Pkce.Generate();

            string scope = "user-read-private user-read-email user-top-read";
            string redirectUrl = "http://localhost:5173/";

            var url = _spotifyAccountService.GenerateOAuthSpotify(scope, redirectUrl, challenge, verifier); //створення url

            //отримую url адреси
            var AllUrl = _urlSpotifyRepository.GetAll();
            var token = AllUrl.Last();

            return Ok(token);
        }
        [HttpPost("Code")]
        public async Task<IActionResult> Code([FromBody] string code)
        {
              string redirectUrl = "http://localhost:5173/";

            //отримую codeVerifier
            var AllUrl = _urlSpotifyRepository.GetAll();
            var token = AllUrl.Last();


            string codeVerifier = token.Verifier;

            await _spotifyAccountService.ExchangeCodeToken(code, codeVerifier, redirectUrl);
    

            return Ok();
        }

        [HttpGet("User")]
        public async Task<IActionResult> User()
        {
            ////я отримав всі токени та за допомогою LINQ передаю останній токен
            var Alltoken = _tokenResultRepository.GetAll();
            var token = Alltoken.Last();

            var userData =  await _getUserData.GetUserDataFunc(token.AccessToken);

            return Ok(userData);
        }

        [HttpGet("Artist")]
        public async Task<IActionResult> GetArtist([FromQuery] string query) 
        {
            ////я отримав всі токени та за допомогою LINQ передаю останній токен
            var Alltoken = _tokenResultRepository.GetAll();
            var token = Alltoken.Last();

            var artist = await _getArtist.GetArtistById(token.AccessToken, query);

            return Ok(artist);
        }
    }
}
