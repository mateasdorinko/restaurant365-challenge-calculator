using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant365.Challenge.Calculator.Application.Interfaces;
using Restaurant365.Challenge.Calculator.Infrastructure.Implementations;
using Restaurant365.Challenge.Calculator.Console;

using var host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try { services.GetRequiredService<App>().Run(args); }
catch (Exception e) { Console.WriteLine(e); }

return;

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
    {
        services.AddSingleton<ICalculator, Calculator>();
        services.AddSingleton<IDelimitedInputParser, DelimitedInputParser>();
        services.AddSingleton<App>();
    });
}