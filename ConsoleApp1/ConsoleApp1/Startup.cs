using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddSingleton((serviceProvider) =>
            {
                return new List<Stack<String>>();
            });
            services.AddSingleton((serviceProvider) =>
            {
                return new List<Queue<String>>();
            });
            services.AddSingleton((serviceProvider) =>
            {
                return new List<List<String>>();
            });
        }

        public void Configure(IApplicationBuilder app)
        {
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();

        }
    }
}
