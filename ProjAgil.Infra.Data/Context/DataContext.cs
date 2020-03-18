using Microsoft.EntityFrameworkCore;
using ProjAgil.Model.Entidades;

namespace ProjAgil.Infra.Data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {}
        public DbSet<Evento> Eventos { get; set; }
    }
}