using BackEnd.Core;
using BackEnd.Core.Interfaces;
using BackEnd.Core.Services.Posts.Commands.CreatePost;
using BackEnd.Infrastructure.Data;
using BackEnd.Infrastructure.Data.Stores;
using BackEnd.Shared.Mediatr;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BackEnd.Api
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
            services.AddMediatR(CoreAssembly.Assembly);

            services.AddControllers();
            services.AddCors();

            services.AddTransient<IPostStore, PostStore>();

            // Add FluentValidation
            AssemblyScanner.FindValidatorsInAssembly(CoreAssembly.Assembly)
                .ForEach(item =>
                {
                    services.AddScoped(item.InterfaceType, item.ValidatorType);
                });
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddDbContext<PostDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            {
                options
                  .AllowAnyHeader()
                  .AllowAnyOrigin()
                  .AllowAnyMethod();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}