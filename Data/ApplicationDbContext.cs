

using System.Reflection.Emit;

namespace GameZone.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> Options):base(Options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(AssemblyBuilder.GetExecutingAssembly());
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Categoris> Categoris { get; set; }
    }
}
