using Microsoft.EntityFrameworkCore;
using Library.Data.Entities;
namespace Library.Data
{
    public class MyWorldDbContext:DbContext
    {
        public MyWorldDbContext(DbContextOptions context):base(context) { }

        public DbSet<Book> Books { get; set; }
    }
}
