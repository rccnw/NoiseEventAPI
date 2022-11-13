using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoiseEventApi.Data.Configurations
{
    public class NoiseEventConfiguration : IEntityTypeConfiguration<NoiseEvent>
    {
        public void Configure(EntityTypeBuilder<NoiseEvent> builder)
        {
            builder.HasData(
                new NoiseEvent
                {
                    Id = 1,
                    Data = "event 1",
                    UtcTime = DateTime.UtcNow.ToString(),
                    Longitude = -122.333056,
                    Latitude = 47.609722
                },
                new NoiseEvent
                {
                    Id = 2,
                    Data = "event 2",
                    UtcTime = DateTime.UtcNow.ToString(),
                    Longitude = -122.3756040651044,
                    Latitude = 47.53405007414973
                },
                new NoiseEvent
                {
                    Id = 3,
                    Data = "event 2",
                    UtcTime = DateTime.UtcNow.ToString(),
                    Longitude = -122.3639542838912,
                    Latitude = 47.536847222433394
                },
                new NoiseEvent
                {
                    Id = 4,
                    Data = "event 3",
                    UtcTime = DateTime.UtcNow.ToString(),
                    Longitude = -122.37644247129047,
                    Latitude = 47.53168586589171
                }
            );
        }
    }
}
