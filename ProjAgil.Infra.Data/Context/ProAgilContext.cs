﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjAgil.Dominio.Entidades;
using ProjAgil.Dominio.Identity;
using System.Reflection;

namespace ProjAgil.Infra.Data.Context
{
    public class ProAgilContext : IdentityDbContext<User, Role, int
                                , IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>
                                , IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ProAgilContext(DbContextOptions<ProAgilContext> options) : base(options) {}
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<RedeSocial> RedesSociais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // registra todos o mapping do EF Fluent API
            // Verifica um determinado assembly para todos os tipos que implementam 
            // IEntityTypeConfiguratione registra cada um automaticamente.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}