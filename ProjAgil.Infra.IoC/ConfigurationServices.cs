using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjAgil.Infra.IoC.Configurations;

namespace ProjAgil.Infra.IoC
{
    public static class ConfigurationServices
    {
        public static void ConfigureDependencyInjection(IServiceCollection services, IConfiguration configuration)
        {
            DatabaseSetup.AddDatabaseSetup(services, configuration);
            AutoMapperSetup.AddAutoMapperSetup(services);
            DependencyInjectionSetup.AddDependencyInjectionSetup(services);
            SwaggerSetup.AddSwaggerSetup(services);
        }
    }
}