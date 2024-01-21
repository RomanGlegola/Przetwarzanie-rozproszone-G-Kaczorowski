using Microsoft.EntityFrameworkCore;
using MyRestApi.Models;

namespace MyRestApi.DbServices
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PersonModel> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            // Seed database with authors and books for demo
            new DbInitializer(builder).Seed();
        }

    }
}
