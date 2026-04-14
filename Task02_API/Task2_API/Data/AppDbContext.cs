using Microsoft.EntityFrameworkCore;
using Task2_API.Models;

namespace Task2_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<JobListing> JobListings { get; set; }
    }
}
