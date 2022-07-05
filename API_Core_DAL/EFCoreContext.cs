using Microsoft.EntityFrameworkCore;

namespace API_Core_DAL
{
    public class EFCoreContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public EFCoreContext(DbContextOptions<EFCoreContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
