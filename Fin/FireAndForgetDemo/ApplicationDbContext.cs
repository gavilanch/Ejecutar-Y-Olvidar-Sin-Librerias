using FireAndForgetDemo.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FireAndForgetDemo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas => Set<Persona>();
        public DbSet<Log> Logs => Set<Log>();
    }
}
