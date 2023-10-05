



namespace GameZone.Services
{
    public class GameService : IGameService
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnv; //To Get Location In Env
        private readonly string ImagesPath;
        public GameService(ApplicationDbContext Context ,IWebHostEnvironment WebHostEnv)
        {
            context = Context;
            webHostEnv = WebHostEnv;
            ImagesPath = $"{WebHostEnv.WebRootPath}{FileSetting.ImagesPath}";
        }
        public async Task Create(CreateGameFromViewModel Model)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(Model.Cover.FileName)}";



            var path = Path.Combine(ImagesPath, CoverName);
            using var Stream=File.Create(path);
            await Model.Cover.CopyToAsync(Stream);

            var Game = new Game()
            {
                Name = Model.Name,
                Description = Model.Description,
                Cover = CoverName,
                CategoreyId= Model.CategoreyId,
                Devices=Model.SelectedDevices.Select(d=> new GameDevice() { DeviceId=d} ).ToList(),
            };
          await  context.AddAsync(Game);
            await context.SaveChangesAsync();
        }
    }
}
