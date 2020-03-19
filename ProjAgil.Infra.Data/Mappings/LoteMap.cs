using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAgil.Dominio.Entidades;

namespace ProjAgil.Infra.Data.Mappings
{
    public class LoteMap: IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .HasColumnType("varchar(250)")
                .HasMaxLength(100)
                .IsRequired();
            
            builder.Property(c => c.DataInicio)
                .HasColumnName("DataInicio")
                .HasColumnType("DateTime")
                .IsRequired(false);

            builder.Property(c => c.DataFim)
                .HasColumnName("DataFim")
                .HasColumnType("DateTime")
                .IsRequired(false);

            builder.Property(c => c.Preco)
                .HasColumnName("Preco")
                .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Quantidade)
                .HasColumnName("Quantidade")
                .HasColumnType("int");

            // relação 1 para muitos
            builder.HasOne<Evento>(s => s.Evento)
                .WithMany(g => g.Lotes)
                .HasForeignKey(s => s.EventoId);
        }
    }
}