using bulkyweb.Models;
using Microsoft.EntityFrameworkCore;

namespace bulkyweb.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }

        public  DbSet<Category>  Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, DisplayOrder = 1, Name = "Action" },
               new Category { Id = 2, DisplayOrder = 2, Name = "SciFi" },
           new Category { Id = 3, DisplayOrder = 3, Name = "Comedy" }
                );
        } 
    }
}
