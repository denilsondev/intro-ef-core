using CursoEfCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace CursoEfCore.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Pedido> Pedidos {get; set;}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=testdb;User Id=SA;Password=password@123;");
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

        }
    }
}