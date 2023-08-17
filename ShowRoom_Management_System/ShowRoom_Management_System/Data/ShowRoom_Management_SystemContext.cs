using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShowRoom_Management_System.Models;

namespace ShowRoom_Management_System.Data
{
    public class ShowRoom_Management_SystemContext : DbContext
    {
        public ShowRoom_Management_SystemContext (DbContextOptions<ShowRoom_Management_SystemContext> options)
            : base(options)
        {
        }

        public DbSet<ShowRoom_Management_System.Models.Bikes> Bikes { get; set; } = default!;
    }
}
