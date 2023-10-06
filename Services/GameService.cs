



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
            var CoverName = await SaveCover(Model.Cover);

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



        public async Task<IEnumerable<Game>> GetAll()
        {
            var Data = await context.Games.AsNoTracking().Include(x => x.Categorey).Include(x => x.Devices).ThenInclude(x => x.Device).ToListAsync(); // To make Not Tracking
            return Data;
        }

        public async Task<Game?> GetById(int id)
        {


            var Data = await context.Games.Include(x=>x.Categorey).Include(x=>x.Devices).ThenInclude(x=>x.Device).SingleOrDefaultAsync(x=>x.Id==id); // To make Not Tracking
            if (Data == null)
                return null;
            return Data;
        }

        public async Task<Game?> Update(EditeGameModelView game)
        {
            var hasNewCover = game.Cover is not null;

            var Game = context.Games.Where(x=>x.Id==game.Id).Include(X=>X.Devices).FirstOrDefault();





            if (Game is null)
                return null;
            var OldCover = Game.Cover;
            Game.Description = game.Description;
            Game.Name = game.Name;
            Game.CategoreyId = game.CategoreyId;
            Game.Devices = game.SelectedDevices.Select(x => new GameDevice { DeviceId = x }).ToList();
            var RowEffict = context.SaveChanges();

            var NewCoverName = await SaveCover(game.Cover!);
     


            if (RowEffict > 0)
            {
                if (hasNewCover)
                {
                    await RemoveCoverOld($"{ImagesPath}/{OldCover}");
                }
                return Game;
            }
            else
            {
                await RemoveCoverOld($"{ImagesPath}/{game.Cover}");
                return null;
            }


        }


        private async Task<string> SaveCover(IFormFile Model)
        {
            var CoverName = $"{Guid.NewGuid()}{Path.GetExtension(Model.FileName)}";
            var path = Path.Combine(ImagesPath, CoverName);
            using var Stream = File.Create(path);
            await Model.CopyToAsync(Stream);
            return CoverName;
        }


        private async Task RemoveCoverOld(string AllPath)
        {
            File.Delete(AllPath);
        }



    }
}
