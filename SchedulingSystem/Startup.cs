using BusinessLayer.Services;
using DBLayer.IRepositories;

using DBLayer.Models;
using DBLayer.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulingSystem
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
            services.AddDbContext<SchedulingSystemContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SchedulingSystemConnection")));
            services.AddControllers();
            services.AddHttpClient();
            services.AddScoped(typeof(IRepoGeneric<Student>), typeof(StudentRepository));
            //services.AddTransient<IRepoGeneric<Student>,StudentRepository>();
            services.AddTransient<StudentService, StudentService>();
            services.AddTransient<IRepoGeneric<StudentClassMapper>, StudentClassMapRepository>();
            services.AddScoped<IRepoExtended<object>, StudentClassMapRepository>();
            services.AddTransient<MappingService, MappingService>();           
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SchedulingSystem", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SchedulingSystem"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
