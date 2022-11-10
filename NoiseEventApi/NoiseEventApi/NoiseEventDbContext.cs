namespace NoiseEventApi
{
    public class NoiseEventDbContext : IdentityDbContext
    {

        public NoiseEventDbContext(DbContextOptions<NoiseEventDbContext> options) : base(options)
        {

        }

        public DbSet<NoiseEvent> NoiseEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var seattle = new Point(-122.333056, 47.609722) { SRID = 4326 };

            modelBuilder.Entity<NoiseEvent>().HasData(
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
                         



            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole
                    {
                        Id = "d1b5952a-2162-46c7-b29e-1a2a68922c14",
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    },
                    new IdentityRole
                    {
                        Id = "42358d3e-3c22-45e1-be81-6caa7ba865ef",
                        Name = "User",
                        NormalizedName = "USER"
                    }
                );

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(
                    new IdentityUser
                    {
                        Id = "408aa945-3d84-4421-8342-7269ec64d949",
                        Email = "admin@localhost.com",
                        NormalizedEmail = "ADMIN@LOCALHOST.COM",
                        NormalizedUserName = "ADMIN@LOCALHOST.COM",
                        UserName = "admin@localhost.com",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                        EmailConfirmed = true
                    },
                    new IdentityUser
                    {
                        Id = "3f4631bd-f907-4409-b416-ba356312e659",
                        Email = "user@localhost.com",
                        NormalizedEmail = "USER@LOCALHOST.COM",
                        NormalizedUserName = "USER@LOCALHOST.COM",
                        UserName = "user@localhost.com",
                        PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                        EmailConfirmed = true
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
