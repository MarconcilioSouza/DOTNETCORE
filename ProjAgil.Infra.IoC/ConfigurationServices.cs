using Microsoft.Extensions.DependencyInjection;
using ProjAgil.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ProjAgil.Infra.IoC
{
    public class ConfigurationServices
    {
        private readonly IServiceCollection services;
        private readonly IConfiguration configuration;
        
        public ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            this.configuration = configuration;
            this.services = services;
        }

        public void ConfigureServices()
        {
            services.AddDbContext<DataContext>(x => x.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}