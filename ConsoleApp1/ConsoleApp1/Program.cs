using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters.Xml;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://localhost:8000");
                }).Build().Run();

            //var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddControllers();  // добавляем поддержку контроллеров

            //var app = builder.Build();

            //// устанавливаем сопоставление маршрутов с контроллерами
            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            //app.Run();

        }

        //public static int someMethod(int a, string someText)
        //{
        //    return 0;
        //}

        public delegate int Sub(int a, string someText);
    }
}