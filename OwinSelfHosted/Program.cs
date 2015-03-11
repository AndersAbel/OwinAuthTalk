using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Owin;

namespace OwinSelfHosted
{
    using AppFunc = Func<IDictionary<string, object>, Task>;

    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:12345";
            Console.WriteLine("Starting web application...");
            using (WebApp.Start(url, Startup))
            {
                Console.WriteLine("Application listening on {0}.", url);
                Console.WriteLine("Press any key to quit.");

                Console.ReadKey();
                Console.WriteLine();
            }

            Console.WriteLine("Application shut down.");
        }

        static void Startup(IAppBuilder app)
        {
            app.Use(new Func<AppFunc, AppFunc>(LoggingMiddleware));

            app.Use(typeof(StartPageMiddleware));
        }

        static AppFunc LoggingMiddleware(AppFunc next)
        {
            return async environment =>
                {
                    Console.WriteLine("Receiving request for \"{0}\"", environment["owin.RequestPath"]);

                    await next.Invoke(environment);

                    Console.WriteLine("Returning with status {0}", environment["owin.ResponseStatusCode"]);
                };
        }
    }
}
