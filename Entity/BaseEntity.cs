
namespace GameZone.Entity
{
    public class BaseEntity
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}
