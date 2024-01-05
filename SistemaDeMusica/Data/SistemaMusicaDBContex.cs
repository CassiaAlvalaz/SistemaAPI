using Microsoft.EntityFrameworkCore;
using SistemaDeMusica.Data.Map;
using SistemaDeMusica.Models;

namespace SistemaDeMusica.Data
{
    public class SistemaMusicaDBContex : DbContext
    {
        public SistemaMusicaDBContex(DbContextOptions<SistemaMusicaDBContex> options) : base(options)
        {
            
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaMusica> Musicas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMusicaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
