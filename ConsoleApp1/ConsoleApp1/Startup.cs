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
        }

        public void Configure(IApplicationBuilder app)
        {
            // добавляем возможности маршрутизации
            app.UseRouting();

            // устанавливаем адреса, которые будут обрабатываться
            app.UseEndpoints(endpoints =>
            {
                // обработка запроса - получаем констекст запроса в виде объекта context
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI();

            //app.Use((HttpContext context, Func<Task> next) =>
            //{

            //    Console.WriteLine(context.Request.Method);
            //    Console.WriteLine(context.Request.Path.ToString());
            //    next();
            //    return Task.Run(() => {

            //    });
            //});

        }
    }
}
