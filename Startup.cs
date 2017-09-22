using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Micro
{
    public class Microservice : Controller, IStartup
    {
        public static void Run<TStartup>(string[] args) where TStartup : class 
            => WebHost.CreateDefaultBuilder(args)
                .UseStartup<TStartup>()
                .Build().Run();

        IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            return services.BuildServiceProvider();
        }

        void IStartup.Configure(IApplicationBuilder app)
            => app.UseMvc();
    }
}
