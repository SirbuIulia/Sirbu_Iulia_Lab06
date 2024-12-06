using Microsoft.EntityFrameworkCore;



namespace Sirbu_Iulia_Lab2.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Sirbu_Iulia_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Sirbu_Iulia_Lab2.Models.Author> Author { get; set; } = default!;

        public DbSet<Sirbu_Iulia_Lab2.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Sirbu_Iulia_Lab2.Models.Genre> Genre { get; set; } = default!;
        public DbSet<Sirbu_Iulia_Lab2.Models.City> City { get; set; } = default!;
        public DbSet<Sirbu_Iulia_Lab2.Models.Order> Order { get; set; } = default!;
        public DbSet<Sirbu_Iulia_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Sirbu_Iulia_Lab2.Models.PublishedBook> PublishedBook { get; set; } = default!;


    }


}


