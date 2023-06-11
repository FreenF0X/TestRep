using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        public void Configure(IApplicationBuilder app)
        {
            Func<HttpContext, Func<Task>, Task> name;
            name = Task (a,b) =>
            {
                return Task.Run(() => {

                });
            };

            app.Use(name); 

            app.Use((HttpContext context, Func<Task> next) =>
            {
                Console.WriteLine(context.Request.Method);
                Console.WriteLine(context.Request.Path.ToString());
                next();
                return Task.Run(() => {
                    
                });
            });

            app.Use((HttpContext context, Func<Task> next) =>
            {
                Console.WriteLine("SomeText");
                next();
                return Task.Run(() => {

                });

            });
        }
    }
}
