using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace KartowkaMarkowkaHab.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddOcelot();
            builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);

            var app = builder.Build();

            app.UseOcelot().Wait();

            app.Run();
        }
    }
}
