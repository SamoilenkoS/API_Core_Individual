using API_Core_DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Core_DAL
{
    public class DbEfContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BookRevision> BookRevisions { get; set; }
        public DbSet<LibraryBook> LibraryBooks { get; set; }
        public DbSet<LibraryRent> LibraryRents { get; set; }

        public DbEfContext(DbContextOptions<DbEfContext> options)
            : base(options)
        {
        }
    }
}
