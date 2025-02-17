using DotNetCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetCRUD.Database
{
    public class ABCDbContext : DbContext
    {
        public ABCDbContext(DbContextOptions options) : base(options)
        {

        }

<<<<<<< HEAD
        public DbSet<Student> Students { get; set; }
=======
        public DbSet<Order> Orders { get; set; }
>>>>>>> 71a23c3c1ac67c2176f5b8d937d981b1327090f1
    }
}
