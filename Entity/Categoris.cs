namespace GameZone.Entity
{
    public class Categoris:BaseEntity
    {

        public ICollection<Game> Games { get; set; }=new List<Game>();
    }
}
