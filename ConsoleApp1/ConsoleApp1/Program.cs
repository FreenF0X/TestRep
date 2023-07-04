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
            var somex = new ServiceCollection();
            somex.AddTransient<Class1>();
            //somex.AddSingleton<int>();
            int i = 0;
            somex.AddSingleton((services) => {
                i++;
                return new Class2(i);
            });


            using (var serviceProvider = somex.BuildServiceProvider())
            {
                var shit1 = serviceProvider.GetRequiredService<Class1>();
                shit1.Class2.Number = 5;
                var shit2 = serviceProvider.GetRequiredService<Class1>();
                var shit3 = serviceProvider.GetRequiredService<Class1>();
            }
                
            

            
            
            
            
            
            
            
            
            
            
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:8000");
                    //webBuilder.UseUrls("http://localhost:8000");
                    //http://192.168.1.123:8000
                }).Build().Run();

        }

        public delegate int Sub(int a, string someText);
    }
}