using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Strapi_Frontend;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Strapi_Frontend.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;


public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        await builder.Build().RunAsync();
    }

    public static void ConfigureServices(IServiceCollection services)
    {
        // Example of loading a configuration as configuration isn't available yet at this stage.
        services.AddSingleton(provider =>
        {
            var config = provider.GetService<IConfiguration>();
            return config.GetSection("App").Get<AppSettings>();
        });
    }
}


