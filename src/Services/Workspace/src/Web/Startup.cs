using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Infrastracture.Identity;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;
using Web.Configurations;


namespace Web
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowAll",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5000",
                                       "http://localhost:4200"
                                       )
                                       .AllowAnyHeader()
                                       .AllowAnyMethod();
                    });
            });
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.
            ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
         );
            services.AddIdentityInfrastructureDependancy(this.Configuration);
            services.AddCoreInjection();
            services.AddInfrastructureDependancy(this.Configuration);
            services.AddWebDependancy();
            services.AddControllers();
            services.AddSwaggerSetup(this.Configuration);
            services.AddHttpContextAccessor();

            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerSetup(this.Configuration);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSerilogRequestLogging();
            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseConsul(this.Configuration);
        }
    }
}
