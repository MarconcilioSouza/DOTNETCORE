using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAgil.Dominio.Entidades;

namespace ProjAgil.Infra.Data.Mappings
{
    public class RedeSocialMap: IEntityTypeConfiguration<RedeSocial>
    {
        public void Configure(EntityTypeBuilder<RedeSocial> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(250)")
                .HasMaxLength(250)
                .IsRequired();
            
            builder.Property(c => c.Url)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            
            // relação 1 para muitos
            builder.HasOne<Evento>(s => s.Evento)
                .WithMany(g => g.RedesSociais)
                .HasForeignKey(s => s.EventoId);
            
            // relação 1 para muitos
            builder.HasOne<Palestrante>(s => s.Palestrante)
                .WithMany(g => g.RedesSociais)
                .HasForeignKey(s => s.PalestrateId);
        }
    }
}