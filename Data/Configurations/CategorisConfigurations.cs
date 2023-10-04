namespace GameZone.Data.Configurations
{
    public class CategorisConfigurations : IEntityTypeConfiguration<Categoris>
    {
        public void Configure(EntityTypeBuilder<Categoris> builder)
        {
            builder.HasData(new Categoris[]
            {
                new Categoris() {Id= 1,Name="Sports" },
                new Categoris() {Id= 2,Name= "Action"},
                new Categoris() {Id= 3,Name= "Adventure"},
                new Categoris() {Id= 4,Name= "Racing"},
                new Categoris() {Id= 5,Name= "Fightng"},
                new Categoris() {Id= 6,Name= "Film"},

                     
            });
        }
    }
}
