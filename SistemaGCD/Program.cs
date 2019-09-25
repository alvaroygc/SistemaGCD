using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SistemaGCD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options => {
                // options.Listen(IPAddress.Loopback, 85);
                options.Listen(IPAddress.Loopback, 86, listenOptions =>
                {
                    listenOptions.UseHttps(Path.Combine(System.AppContext.BaseDirectory, "cacert.pfx"), "C@lder0n");
                });
            })

                .UseStartup<Startup>();
    }
}
