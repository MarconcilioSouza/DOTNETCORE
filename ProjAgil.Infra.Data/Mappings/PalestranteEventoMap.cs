using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAgil.Dominio.Entidades;

namespace ProjAgil.Infra.Data.Mappings
{
    public class PalestranteEventoMap : IEntityTypeConfiguration<PalestranteEvento>
    {
        public void Configure(EntityTypeBuilder<PalestranteEvento> builder)
        {
            builder.HasKey(x => new { x.EventoId , x.PaletranteId });
        }
    }
}