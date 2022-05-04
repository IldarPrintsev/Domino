using DominoApp.Abstract;
using DominoApp.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace DominoApp
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            using var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                services.AddScoped<IDominoService, DominoService>()).Build();
            using var serviceScope = host.Services.CreateScope();
            var provider = serviceScope.ServiceProvider;

            var service = provider.GetRequiredService<IDominoService>();
            var initialData = service.ParseInputs();
            var result = service.Calculate(initialData);


            return host.RunAsync();
        }
    }
}
