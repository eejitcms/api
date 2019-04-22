using App.Metrics.AspNetCore;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace EejitCMS.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateWebHostBuilder(args).Build().Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseSerilog((context, config) =>
				{
					config.ReadFrom.Configuration(context.Configuration);
				})
				.ConfigureAppMetricsHostingConfiguration(options =>
				{
					options.AllEndpointsPort = 3333;
					options.EnvironmentInfoEndpoint = "/env";
					options.MetricsEndpoint = "/metrics";
					options.MetricsTextEndpoint = "/metrics-text";
				})
				.UseMetrics()
				.UseStartup<Startup>();
	}
}
