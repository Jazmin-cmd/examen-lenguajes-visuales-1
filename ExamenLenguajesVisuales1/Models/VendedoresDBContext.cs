using ExamenLenguajesVisuales1.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamenLenguajesVisuales1.Models
{

    public class VendedoreDBContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Venta> Ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-EHBFEI0;Initial Catalog=VendedoresDB;Integrated Security=True;");
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-EHBFEI0;Initial Catalog=VendedoreDB;Integrated Security=True;");
        }
    }

}


