using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
