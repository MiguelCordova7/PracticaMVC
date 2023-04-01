using Microsoft.EntityFrameworkCore;

namespace PracticaMVC.Models
{
    public class equiposDbContext: DbContext
    {
        public equiposDbContext(DbContextOptions<equiposDbContext> options) : base(options) { }

        public DbSet<marcas> marcas { get; set; }

        public DbSet<carreras> carreras { get; set; }

        public DbSet<estadosEquipo> estadosEquipo { get; set; }

        public DbSet<estadosReserva> estadosReservas { get; set; }

        public DbSet<facultades> facultades {get; set; }

        public DbSet<tipoEquipo> tipoEquipo { get; set; }
        
        public  DbSet<usuarios> usuarios { get; set; }
    }
    
}
