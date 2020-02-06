using Microsoft.EntityFrameworkCore;
using CadastrarMeApi.Domain.Entities;
using CadastrarMeApi.Infra.Persistence.Maps;

namespace CadastrarMeApi.Infra.Persistence.DataContexts
{
    public class CadastrarMeDataContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=localhost,1433;Database=dbCadMe;User ID=SA;Password=MNRMNR87@");
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=master;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMapping());
            modelBuilder.ApplyConfiguration(new EnderecoMapping());
        }
    }
}