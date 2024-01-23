using Microsoft.EntityFrameworkCore;

namespace DbOperationsWithEFCoreApp.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        // Data Seeding (Insert into Master Data)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Title="INR", Description="Indian INR"},
                new Currency() { Id = 2, Title="NPR", Description= "Nepali NPR" },
                new Currency() { Id = 3, Title="Euro", Description= "Euro" },
                new Currency() { Id = 4, Title="Dinar", Description= "Dinar" }
            );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = 1, Title = "English", Description = "English Language" },
                new Language() { Id = 2, Title = "Nepali", Description = "Nepali Language" },
                new Language() { Id = 3, Title = "French", Description = "French Language" },
                new Language() { Id = 4, Title = "Chinese", Description = "Chinese Language" }
            );
        }

        // DbSet for Class and create Table for it.
        public DbSet<Book> Books { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<BookPrice> BookPrices { get; set; }
    }
}
