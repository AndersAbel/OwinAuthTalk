using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinSelfHosted
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:12345";
            Console.WriteLine("Starting web application...");
            using(WebApp.Start(url, Startup))
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

        }
    }
}
