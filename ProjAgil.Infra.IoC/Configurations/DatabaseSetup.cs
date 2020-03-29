using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjAgil.Infra.Data.Context;

namespace ProjAgil.Infra.IoC.Configurations
{
    public static class DatabaseSetup
    {
        /// <summary>
        /// Configuração do data context e conexão do banco
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddDatabaseSetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) 
                throw new ArgumentNullException(nameof(services));

            services.AddDbContext<ProAgilContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}