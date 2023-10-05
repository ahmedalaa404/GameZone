

namespace GameZone.Data.Configurations
{
    public class GameDeviceConfiguration : IEntityTypeConfiguration<GameDevice>
    {
        public void Configure(EntityTypeBuilder<GameDevice> builder)
        {
            builder.HasKey(x => new { x.DeviceId, x.GameId });

        }
    }
}
