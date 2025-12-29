using FullStack.Net.DI.ConsoleDesk;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<IPerson, Person>();
                services.AddTransient<ConsoleApp>();
            })
            .Build();

        using (var serviceScope = host.Services.CreateScope())
        {
            var services = serviceScope.ServiceProvider;

            try
            {
                ConsoleApp consoleApp = services.GetRequiredService<ConsoleApp>();
                await consoleApp.RunAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occured");
                Console.WriteLine(ex);
            }
        }
    }
}