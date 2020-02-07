using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CadastrarMeApi.Domain.Repositories;
using CadastrarMeApi.Domain.ApplicationServices;
using CadastrarMeApi.Infra;
using CadastrarMeApi.Infra.Repositories;
using CadastrarMeApi.Infra.Persistence.DataContexts;
using CadastrarMeApi.ApplicationService.Services;
using Microsoft.OpenApi.Models;

namespace CadastrarMeApi.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CadastrarMeDataContext>();
            // services.AddScoped<CadastrarMeDataContext, CadastrarMeDataContext>();

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteApplicationService, ClienteApplicationService>();

            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<IEnderecoApplicationService, EnderecoApplicationService>();

            services.AddControllers();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Cadastrar-me api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cadastrar-me api - v1");
            });

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
