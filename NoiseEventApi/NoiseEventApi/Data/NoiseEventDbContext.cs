namespace NoiseEventApi.Data
{
    public class NoiseEventDbContext : IdentityDbContext<ApiUser>
    {

        public NoiseEventDbContext(DbContextOptions<NoiseEventDbContext> options) : base(options)
        {

        }

        public DbSet<NoiseEvent> NoiseEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new NoiseEventConfiguration());

            var hasher = new PasswordHasher<ApiUser>();

            modelBuilder.Entity<ApiUser>().HasData(
                    new ApiUser
                    {
                        Id = "408aa945-3d84-4421-8342-7269ec64d949",
                        Email = "admin@localhost.com",
                        NormalizedEmail = "ADMIN@LOCALHOST.COM",
                        NormalizedUserName = "ADMIN@LOCALHOST.COM",
                        UserName = "admin@localhost.com",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                        EmailConfirmed = true,
                        FirstName = "Rob",
                        LastName = "Campbell"
                    },
                    new ApiUser
                    {
                        Id = "3f4631bd-f907-4409-b416-ba356312e659",
                        Email = "user@localhost.com",
                        NormalizedEmail = "USER@LOCALHOST.COM",
                        NormalizedUserName = "USER@LOCALHOST.COM",
                        UserName = "user@localhost.com",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                        EmailConfirmed = true,
                        FirstName = "Rob",
                        LastName = "Campbell"
                    }
                );

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                     new IdentityUserRole<string>
                     {
                         RoleId = "d1b5952a-2162-46c7-b29e-1a2a68922c14",
                         UserId = "408aa945-3d84-4421-8342-7269ec64d949",
                     },
                    new IdentityUserRole<string>
                    {
                        RoleId = "42358d3e-3c22-45e1-be81-6caa7ba865ef",
                        UserId = "3f4631bd-f907-4409-b416-ba356312e659",
                    }
                );

        }
    }
}
