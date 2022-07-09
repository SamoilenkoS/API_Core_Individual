using API_Core_DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace API_Core_DAL
{
    public class DbEfContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbEfContext(DbContextOptions<DbEfContext> options)
            : base(options)
        {
        }
    }
}
