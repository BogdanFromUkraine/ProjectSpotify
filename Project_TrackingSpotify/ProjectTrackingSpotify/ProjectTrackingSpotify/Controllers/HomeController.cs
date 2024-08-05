using Microsoft.AspNetCore.Mvc;
using ProjectTrackingSpotify.Models;
using ProjectTrackingSpotify.Services.GetUserIsTopItems;
using ProjectTrackingSpotify.Services;
using System.Diagnostics;
using System.Text;
using ProjectTrackingSpotify.Utility;
using ProjectTrackingSpotify.DataAccess.Repository.IRepository;
using Newtonsoft.Json.Linq;
using Hangfire;


namespace ProjectTrackingSpotify.Controllers
{


	[ApiController]
	[Route("api/[controller]")]
	public class HomeController : ControllerBase
    {
		private readonly ISpotifyAccountService _spotifyAccountService;		
		private readonly IGetUserIsTopItems _getUsersItem;
		
		
        public HomeController(ISpotifyAccountService spotifyAccountService,
			IGetUserIsTopItems getUserItem,
			IPkceCode pkceCode)
		{
			_spotifyAccountService = spotifyAccountService;
			_getUsersItem = getUserItem;	

		}

        
        public async Task<IActionResult> Index()
		{

            //HttpContext.Session.SetString("codeVerifier", verifier);
            //HttpContext.Session.SetString("codeChallenge", challenge);

            return Content("Hello");
		}

		
		public IActionResult AuthScreen() 
		{
            try
            {

                

                //string challenge = HttpContext.Session.GetString("codeChallenge");
                //HttpContext.Response.Cookies.Append("verifier", verifier);

                //return Redirect(url);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

			return Error();
		}
		

       
        public IActionResult Privacy()
		{
			return Ok();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return Ok(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

