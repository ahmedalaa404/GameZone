

using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


    }
}
