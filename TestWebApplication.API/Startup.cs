using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TestWebApplication.Domain.Interface;
using TestWebApplication.Domain.Services;
using TestWebApplication.Data.Context;
using TestWebApplication.Application.Bll;
using TestWebApplication.API.Controllers;
using TestWebApplication.Application.Interface;

namespace TestWebApplication.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>( );
            services.AddScoped<IUserBll, UserBll>( );

            services.AddControllers( );
            services.AddDbContext<AppDbContext>( options =>
            {
                options.UseSqlServer( Configuration.GetConnectionString( "MyDbCon" ) );
            } );
            services.AddSwaggerGen( s =>
            {
                s.SwaggerDoc( "v1", new OpenApiInfo { Title = "Test API", Version = "v1" } );
            } );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if ( env.IsDevelopment( ) )
            {
                app.UseDeveloperExceptionPage( );
            }

            app.UseSwagger( );

            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint( "/swagger/v1/swagger.json", "Test API V1" );
                c.RoutePrefix = "swagger";
            } );

            app.UseHttpsRedirection( );

            app.UseRouting( );

            app.UseAuthorization( );

            app.UseEndpoints( endpoints =>
             {
                 endpoints.MapControllers( );
             } );
        }
    }
}
