using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Scorponok.IB.Cqrs.Data.Context;
using Scorponok.IB.Cross.Cutting.Ioc;

//using Swashbuckle.Swagger;


namespace Scorponok.IB.Web.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment configuration)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{configuration.EnvironmentName}.json", optional: true);

            //if (configuration.IsDevelopment()) builder.AddUserSecrets<Startup>();
            
            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //Registering interfaces
            Setup.RegisterServices(services);

            services.AddMvc();

            StartupSwagger.ConfigureServices(services);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            

            //app.UseCors(c =>
            //{
            //    c.AllowAnyHeader();
            //    c.AllowAnyMethod();
            //    c.AllowAnyOrigin();
            //});

            app.UseMvc();

            StartupSwagger.Configure(app, env);
            
        }
    }
}
