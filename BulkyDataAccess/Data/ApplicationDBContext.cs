using BulkyBook.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAcess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Akanni Emmanuel", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "Adedayo Micheal", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "Adejare Mathew", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product { Author = "Akanni Emmanuel", Title = "Habits", ISBN = "1234", PId = 1, ListPrice = 200, Price = 180, Price50 = 150, Price100 = 100, Description = "I'm a short story bro" },
                    new Product { Author = "Akanni Emmanuel", Title = "Habits", ISBN = "1234", PId = 2, ListPrice = 200, Price = 180, Price50 = 150, Price100 = 100, Description = "I'm a short story bro" },
                    new Product { Author = "Akanni Emmanuel", Title = "Habits", ISBN = "1234", PId = 3, ListPrice = 200, Price = 180, Price50 = 150, Price100 = 100, Description = "I'm a short story bro" }
                );
        }
    }
}
