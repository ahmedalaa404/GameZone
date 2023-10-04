namespace GameZone.Data.Configurations
{
    public class DevicesConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasData(new Device[] {
                new Device { Id = 1,Name="PlayStation",Icone="bi bi-playstation"},
                new Device { Id = 2,Name="XBox",Icone="bi bi-xbox"},
                new Device { Id = 3,Name="Pc",Icone="bi bi-pc-display-horizontal"},
                new Device { Id = 4,Name="Phone",Icone="bi bi-phone"},
                new Device { Id = 4,Name="Nintendo Switch",Icone="bi bi-nintendo-switch"},





            });


        }
    }
}
