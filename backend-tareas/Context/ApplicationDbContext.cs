using backend_tareas.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_tareas.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Tarea> Tareas { get; set; }
    }
}
