using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace Scorponok.IB.Web.Api.Middlewares
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerInApplication(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Epimed API Documentation - V1");
            });

            return app;
        }
    }
}