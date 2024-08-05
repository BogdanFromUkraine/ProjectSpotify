using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using ProjectTrackingSpotify.Services;
using System.Diagnostics;

namespace ProjectTrackingSpotify.Controllers
{
    [Route("Home/Privacy")]
    public class NotificationController : Controller
    {
        private readonly ISpotifyAccountService _spotifyAccountService;
        public NotificationController(ISpotifyAccountService spotifyAccountService)
        {
            _spotifyAccountService = spotifyAccountService;
        }

        //метод, який буде оновляти токен кожну годину
        public IActionResult Recurring()
        {
            

            string token = HttpContext.Session.GetString("refreshToken");
            int? tokenId = HttpContext.Session.GetInt32("tokenId");
            RecurringJob.AddOrUpdate(() => _spotifyAccountService.RefreshToken(token, tokenId), Cron.Hourly);

            return Ok();
        }

        //public IActionResult Foo() 
        //{
        //    string token = HttpContext.Session.GetString("refreshToken");
        //    int? tokenId = HttpContext.Session.GetInt32("tokenId");
        //    string jobId = BackgroundJob.Enqueue(() =>  _spotifyAccountService.RefreshToken(token, tokenId));

        //    return Ok(jobId);
        //}



    }
}
