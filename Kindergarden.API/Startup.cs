using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Kindergarden.Application.Infrastructure;
using Kindergarden.Application.Interfaces;
using Kindergarden.Persistence;
using Kindergarden.API.Filters;
using NSwag.AspNetCore;
using System.Reflection;
using Kindergarden.Application.Infrastructure.Automapper;
using Kindergarden.Application.Groups.Queries.GetGroupList;
using Kindergarden.Application.Groups.Commands.CreateGroup;

namespace Kindergarden.API
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
            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add framework services.
            //services.AddTransient<INotificationService, NotificationService>();
            //services.AddTransient<IDateTime, MachineDateTime>();

            // Add MediatR
            services.AddMediatR(typeof(GetGroupListQueryHandler).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            //// Add DbContext using SQL Server Provider
            services.AddDbContext<IKindergardenContext, KindergardenContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("KindergardenDatabase")));

            services
                .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateGroupCommandValidator>()); //registra todos los FV del assembly que contiene a este, podria haber elegido cualquiera

            services.AddOpenApiDocument(config => { 
                config.Description = "API Documentation for Kindergarden";
                config.Title = "Kindergarden";
            });

            // Customise default API behavior
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseHttpsRedirection();
            //app.UseStaticFiles();
            //app.UseSpaStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUi3();

            app.UseMvc();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller}/{action=Index}/{id?}");
            //});

            //app.UseSpa(spa =>
            //{
            //    // To learn more about options for serving an Angular SPA from ASP.NET Core,
            //    // see https://go.microsoft.com/fwlink/?linkid=864501

            //    spa.Options.SourcePath = "ClientApp";

            //    if (env.IsDevelopment())
            //    {
            //        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
            //    }
            //});
        }
    }
}
