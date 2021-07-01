
using kino2.Common;
using kino2.Context;
using kino2.controllers;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace kino2
{
    public class Startup
    {
        public IConfigurationRoot _conf;
        public IConfiguration Configuration { get; }
        public Startup( IConfiguration configuration, IWebHostEnvironment hostenv)

        {
            _conf = new ConfigurationBuilder().SetBasePath(hostenv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            


            services.AddControllers();

            services.AddMvc();

            var authOptionsConfiguration = Configuration.GetSection("auth");
            services.Configure<AuthOptions>(authOptionsConfiguration); // регистрирует контроллер как зависимость 

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    buider =>
                    {
                        buider.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseCors();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
