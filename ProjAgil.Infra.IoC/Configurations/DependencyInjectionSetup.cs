using System;
using Microsoft.Extensions.DependencyInjection;
using ProjAgil.Application.Services;
using ProjAgil.Infra.Data.Context;
using ProjAgil.Infra.Data.Repositorio;
using ProjAgil.Dominio.Interfaces.Aplicacao;
using ProjAgil.Dominio.Interfaces.Repositorio;

namespace ProjAgil.Infra.IoC.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            // Application
            services.AddScoped<IEventoAppService, EventoAppService>();
            services.AddScoped<IPalestranteAppServece, PalestranteAppServece>();

            // Infra - Data
            services.AddScoped<IEventoRepositorio, EventoRepositorio>();
            services.AddScoped<IPalestranteRepositorio, PalestranteRepositorio>();
            services.AddScoped<ProAgilContext>();
        }
    }
}