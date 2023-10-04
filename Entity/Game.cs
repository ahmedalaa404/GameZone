

namespace GameZone.Entity
{
    public class Game:BaseEntity
    {

        [MaxLength(2500)]

        public string  Description { get; set; } = string.Empty;

        public string Cover { get; set; } = string.Empty;

        #region Navigation Property Category
        public int CategoreyId { get; set; }



        public Categoris Categorey { get; set; } = default!;
        #endregion



        #region Relations Many to Many With Devices Can Run As It


        public ICollection<GameDevice> Devices { get; set; } = new List<GameDevice>();

        #endregion

    }
}
