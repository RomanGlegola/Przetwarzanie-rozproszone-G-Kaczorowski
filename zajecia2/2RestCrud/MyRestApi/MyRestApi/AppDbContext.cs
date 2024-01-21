using Microsoft.EntityFrameworkCore;
using MyRestApi.Models;

namespace MyRestApi
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PersonModel> Persons { get; set; }
    }
}
