using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjAgil.Dominio.Identity;
using ProjAgil.Infra.Data.Context;
using System;

namespace ProjAgil.Infra.IoC.Configurations
{
    public static class IdentitySetup
    {
        /// <summary>
        /// Configuração do identity, autenticação do usuário
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddIdentitySetup(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            // configurações do passaword ...
            IdentityBuilder builder = services.AddIdentityCore<User>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
            });

            builder = new IdentityBuilder(builder.UserType, typeof(Role), builder.Services);
            builder.AddEntityFrameworkStores<ProAgilContext>();
            builder.AddRoleValidator<RoleValidator<Role>>();
            builder.AddRoleManager<RoleManager<Role>>();
            builder.AddSignInManager<SignInManager<User>>();
        }
    }
}
