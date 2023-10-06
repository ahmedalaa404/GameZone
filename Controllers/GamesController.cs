



using GameZone.Entity;
using GameZone.Services;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        [HttpGet]
        public IActionResult Update([FromRoute] int Id, int id)
        {
            if (id != Id)
            return BadRequest(id);
            var model = gameServices.GetById(id).Result;
            if (model is null)
                return NotFound();
            EditeGameModelView Data = new EditeGameModelView()
            {
                Id = id,
                Name = model.Name,
                Description = model.Description,
                CategoreyId = model.CategoreyId,
                SelectedDevices = model.Devices.Select(x => x.DeviceId).ToList(),
                Categores = categories.GetSelectList(),
                 Devices = categories.GetSelectListDevices(),
                 CurrentCover=model.Cover
            };
            return View(Data);
        }

        [HttpPost] //By Defulte 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EditeGameModelView Model)
        {
            if (!ModelState.IsValid)
            {
                Model.Categores = categories.GetSelectList();
                Model.Devices = categories.GetSelectListDevices();
                return View(Model);
            }
          var game=  await gameServices.Update(Model);

            if (game is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }
















        [HttpGet]
        public IActionResult Details([FromRoute]int id, int ID) 
        {
            if(id != ID)
                return BadRequest(id);

        var model=  gameServices.GetById(id).Result;
            if(model is null)
                return NotFound();

            return View(model);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute]int Id,int id) 
        {
            if (id != Id)
                return BadRequest(id);

            var IsDelete= await gameServices.Delete(id);

            return IsDelete?Ok():BadRequest();


        }


















        [HttpPost]

        public IActionResult Delete([FromRoute] int Id,Game Model)
        {

            if(Id != Model.Id)
                return BadRequest();
            if(ModelState.IsValid)
            return View("Index");
            else
            {

                return View(Model);

            }
        }







    }
}

