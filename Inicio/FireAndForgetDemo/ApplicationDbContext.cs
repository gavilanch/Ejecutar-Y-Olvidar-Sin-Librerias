using FireAndForgetDemo.Entidades;
using Microsoft.EntityFrameworkCore;

namespace FireAndForgetDemo
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Log> Logs { get; set; }
    }
}
