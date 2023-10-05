



using GameZone.Entity;
using GameZone.Services;

namespace GameZone.Controllers
{
    public class GamesController : Controller
    {
        
        private readonly ICategorieyServices categories;
        private readonly IGameService gameServices;

        public GamesController(ICategorieyServices Categories,IGameService GameServices)
        {

            categories = Categories;
            gameServices = GameServices;
        }


        public async Task<IActionResult> Index()
        {
            var Model = await gameServices.GetAll();
            return View(Model);
        }











        [HttpGet] //By Defulte 
        public IActionResult Create()
        {


            CreateGameFromViewModel ViewModel = new CreateGameFromViewModel()
            {
                Categores = categories.GetSelectList(),

                Devices = categories.GetSelectListDevices(),
            };
            return View(ViewModel);
        }

        [HttpPost] //By Defulte 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateGameFromViewModel Model)
        {
            if(!ModelState.IsValid)
            {
                Model.Categores= categories.GetSelectList();

                Model.Devices = categories.GetSelectListDevices();

                return View(Model);
            }
            await gameServices.Create(Model);
            return RedirectToAction(nameof(Index));
        }











    }
}

