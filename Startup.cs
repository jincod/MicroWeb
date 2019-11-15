using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Micro
{
	public class Microservice : ControllerBase, IStartup
	{
		IServiceProvider IStartup.ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            return services.BuildServiceProvider();
		}

		void IStartup.Configure(IApplicationBuilder app)
		{
			app
                .UseRouting()
                .UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}

		public static void Run<TStartup>(string[] args) where TStartup : class
		{
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<TStartup>()
				.Build()
				.Run();
		}
	}
}