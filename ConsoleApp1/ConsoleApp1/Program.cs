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

            Sub x = (a, t) =>
            {
                return 0;
            };

            x(3,"sp[diobmvpsibk");
            
        
        }

        //public static int someMethod(int a, string someText)
        //{
        //    return 0;
        //}

        public delegate int Sub(int a, string someText);
    }
}