using Microsoft.AspNetCore.Mvc;

namespace ProjectTrackingSpotify.Controllers
{
    [Route("Test/Index")]
    public class TestContoller : Controller
    {
        public IActionResult Index() 
        {
            return View();
        }

    }
}
