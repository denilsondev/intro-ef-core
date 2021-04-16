using CursoEfCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEfCore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

        }
    }
}