using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAcess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Akanni Emmanuel", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "Adedayo Micheal", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "Adejare Mathew", DisplayOrder = 3 }
                );
        }
    }
}
