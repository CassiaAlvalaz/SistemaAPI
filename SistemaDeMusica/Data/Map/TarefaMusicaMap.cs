using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SistemaDeMusica.Models;

namespace SistemaDeMusica.Data.Map
{
    public class TarefaMusicaMap : IEntityTypeConfiguration<TarefaMusica>
    {
        public void Configure(EntityTypeBuilder<TarefaMusica> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeMusica).IsRequired().HasMaxLength(300);
            builder.Property(x => x.AvaliacaoDaMusica).IsRequired().HasMaxLength(100);
            builder.Property(x => x.NotaDaMusica).IsRequired();
            builder.Property(x => x.UsuarioId).IsRequired();

            builder.HasOne(x => x.Usuario);
        }
    }
}
