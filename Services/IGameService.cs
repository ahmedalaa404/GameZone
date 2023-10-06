namespace GameZone.Services
{
    public interface IGameService
    {
        Task Create (CreateGameFromViewModel Model);

        Task<IEnumerable<Game>> GetAll();
        Task<Game?> GetById(int id);
        
        Task<Game?> Update(EditeGameModelView game);

        Task<bool> Delete(int id);    

    }
}
