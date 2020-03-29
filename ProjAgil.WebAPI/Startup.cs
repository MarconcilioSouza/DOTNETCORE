using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjAgil.Infra.IoC;
using ProjAgil.Infra.IoC.Configurations;
using Microsoft.Extensions.FileProviders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace ProjAgil.WebAPI
{
    /// <summary>
    /// Startup do projeto
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// IConfiguration
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            DatabaseSetup.AddDatabaseSetup(services, Configuration);
            IdentitySetup.AddIdentitySetup(services, Configuration);
            AuthenticationJwtSetup.AddAuthenticationJwtSetup(services, Configuration);
            AutoMapperSetup.AddAutoMapperSetup(services);
            DependencyInjectionSetup.AddDependencyInjectionSetup(services);
            SwaggerSetup.AddSwaggerSetup(services);

            // Determinar que a api vai chamar uma determinada controller
            services.AddMvc(options =>
            {
                // configuração que obrigar que seja informado uma autenticação
                // garante que todas as requests sejam autenticadas
                var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

                options.Filters.Add(new AuthorizeFilter(policy));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            // Configuração para não retorna referencia cicular no json
            .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddCors();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions(){
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
                RequestPath = new PathString("/Resources"),
            });
            app.UseMvc();

            SwaggerSetup.UseSwaggerSetup(app);
        }
    }
}
