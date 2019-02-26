using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Scorponok.IB.Cross.Cutting.Ioc;
using Swashbuckle.AspNetCore.Swagger;

namespace Scorponok.IB.Web.Api.Configurations
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            NativeInjectionDependency.RegisterServices(services);
            return services;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = " Project - Cadastro Geral de Membros de Congreção",
                    Description = "Cadastro Geral de Membros de Congreção API Swagger surface",
                    Contact = new Contact
                    {
                        Name = "Artur Rineiro",
                        Email = "arturrj@gmail.com",
                        Url = "https://github.com/ArturRibeiro/Scorponok.IB.Cqrs"
                    },
                    License = new License { Name = "MIT", Url = "https://github.com/ArturRibeiro/Scorponok.IB.Cqrs" }
                });

                var xmlComments = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, $"{PlatformServices.Default.Application.ApplicationName}.xml");
                s.IncludeXmlComments(xmlComments);
                //s.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization-Monitor", Type = "apiKey" });
            });

            return services;
        }
    }
}