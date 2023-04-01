using Microsoft.EntityFrameworkCore;

using Test_Backend.Domain.Models;

namespace Test_Backend.Infrastructurre
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .Properties<DateTimeOffset>()
                .HaveConversion<DateTimeOffsetConverter>();
        }

        public DbSet<AdvertisementModel> Advertisements { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
    }
}
