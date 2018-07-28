using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Scorponok.IB.Web.Api
{
    public static class StartupSwagger
    {


        public static void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                //TODO:[scorponok][bug]: https://github.com/domaindrivendev/Swashbuckle.AspNetCore/issues/559
                s.SwaggerEndpoint("/swagger/swagger/v1/swagger.json", "Project Cadastro Geral de Membros de Congreção API v1.1");
            });
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = " Project - Cadastro Geral de Membros de Congreção",
                    Description = "Cadastro Geral de Membros de Congreção API Swagger surface",
                    Contact = new Contact { Name = "Artur Rineiro", Email = "arturrj@gmail.com", Url = "https://github.com/ArturRibeiro/Scorponok.IB.Cqrs" },
                    License = new License { Name = "MIT", Url = "https://github.com/ArturRibeiro/Scorponok.IB.Cqrs" }
                });
            });
        }
    }
}
