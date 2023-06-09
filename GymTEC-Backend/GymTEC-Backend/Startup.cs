﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GymTEC_Backend.Repositories;
using GymTEC_Backend.Repositories.Interfaces;
using GymTEC_Backend.Models.Interfaces;
using GymTEC_Backend.Models;

namespace GymTEC_Backend
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddRazorPages();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<SqlOptions>(configRoot);
            services.AddScoped<IClientModel, ClientModel>();
            services.AddScoped<IEmployeeModel, EmployeeModel>();
            services.AddScoped<IGymTecRepository, GymTecRepository>();
            services.AddScoped<IBranchModel, BranchModel>();

        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:4200");
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
