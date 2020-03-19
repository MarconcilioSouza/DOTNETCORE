using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAgil.Dominio.Entidades;

namespace ProjAgil.Infra.Data.Mappings
{
    public class PalestranteMap: IEntityTypeConfiguration<Palestrante>
    {
        public void Configure(EntityTypeBuilder<Palestrante> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(250)")
                .HasMaxLength(250)
                .IsRequired();
            
            builder.Property(c => c.MiniCurriculo)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.ImagemUrl)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(100)")
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}