using DataReader.Core.Ports;
using DataReader.Infra.Settings;
using DataReader.Infra.Storage;
using DataWorker;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var settings = context.Configuration.Get<AppSettings>();
        services.AddSingleton(settings);
        services.AddHostedService<Worker>();
        services.AddTransient<IFilePort, FileAdapter>();
    })
    .Build();

await host.RunAsync();
