using Microsoft.EntityFrameworkCore;
using vroom_with_mvc.Models;

namespace vroom_with_mvc.AppDbContext
{
    public class VroomDbContext:DbContext
    {
        public VroomDbContext(DbContextOptions<VroomDbContext> options) :
            base(options)
        { }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }

    }
}
