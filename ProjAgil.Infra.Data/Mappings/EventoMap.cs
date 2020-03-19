using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjAgil.Dominio.Entidades;

namespace ProjAgil.Infra.Data.Mappings
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Local)
                .HasColumnType("varchar(250)")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Telefone)
                .HasColumnType("varchar(30)")
                .HasMaxLength(30)
                .IsRequired(); 

            builder.Property(c => c.Tema)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200)
                .IsRequired(); 
            
            builder.Property(c => c.DataEvento)
                .HasColumnType("DateTime")
                .IsRequired();
            
            builder.Property(c => c.QtdPessoas)
                .HasColumnType("int")
                .IsRequired();
            
            builder.Property(c => c.ImagemUrl)
                .HasColumnType("varchar(200)")
                .HasMaxLength(200);        
        }
    }
}