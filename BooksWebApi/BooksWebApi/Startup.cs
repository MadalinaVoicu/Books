using AutoMapper;
using BooksWebApi.Contexts;
using BooksWebApi.Services.Repositories;
using BooksWebApi.Services.UnitsOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace BooksWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // SS: Represents a set of key/value application configuration properties.
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //SS: ConfigureServices is used to add services on the container and to configure those services.
            //SS: All the services we add here can later be injected into other pieces of code that live in our application.

            // Register the DbContext on the container, getting the connection string from appSettings.
            // (Note: Use this during development; In a production environment, it's better to store the connection string in an environment variable)
            var connectionString = Configuration["ConnectionStrings:BooksDBConnectionString"];
            services.AddDbContext<BooksContext>(o => o.UseSqlServer(connectionString));

            // SS: Adding services on the container
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();

            services.AddScoped<IUserUnitOfWork, UserUnitOfWork>();
            services.AddScoped<IBookUnitOfWork, BookUnitOfWork>();

            services.AddControllers();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //SS: This method is called after the ConfigureServices because it uses services that are registered and configured in the ConfigureServices method.
            //SS: The Configure method is used to specify how an ASP.NET Core application will respond to individual requests.

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
