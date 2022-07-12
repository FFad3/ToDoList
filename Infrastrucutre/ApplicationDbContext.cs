using Core.Enttities;
using Microsoft.EntityFrameworkCore;

namespace Infrastrucutre
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }
        public DbSet<Priority> Priorities { get; set; }
    }
}