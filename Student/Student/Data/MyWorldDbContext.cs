
using Microsoft.EntityFrameworkCore;
using Student.Data.Entities;
namespace Student.Data;

public class MyWorldDbContext:DbContext
{
    public MyWorldDbContext(DbContextOptions<MyWorldDbContext> context) : base(context)
    { }
    public DbSet<Student> Students { get; set; }
}

