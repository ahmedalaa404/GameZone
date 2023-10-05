namespace GameZone.Services
{
    public interface IGameService
    {
        Task Create (CreateGameFromViewModel Model);

        Task<IEnumerable<Game>> GetAll();

    }
}
