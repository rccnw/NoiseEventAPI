using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoiseEventApi.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "d1b5952a-2162-46c7-b29e-1a2a68922c14",
                    Name = "Admininistrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "42358d3e-3c22-45e1-be81-6caa7ba865ef",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
