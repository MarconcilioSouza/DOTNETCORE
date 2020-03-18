using System;
using Microsoft.Extensions.DependencyInjection;
using ProjAgil.Application.Services;
using ProjAgil.Infra.Data.Context;
using ProjAgil.Infra.Data.Repositorio;
using ProjAgil.Model.Interfaces.Aplicacao;
using ProjAgil.Model.Interfaces.Repositorio;

namespace ProjAgil.Infra.IoC.Configurations
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

             // Domain Bus (Mediator)

            // ASP.NET Authorization Polices

            // Application
            services.AddScoped<IEventoAppService, EventoAppService>();

            // Domain - Events

            // Domain - Commands

            // Infra - Data
            services.AddScoped<IEventoRepositorio, EventoRepositorio>();
            services.AddScoped<DataContext>();

            // Infra - Data EventSourcing

            // Infra - Identity
        }
    }
}