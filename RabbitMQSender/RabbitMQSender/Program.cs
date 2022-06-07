using Microsoft.Extensions.DependencyInjection;
using RabbitMQSender.Adapter;
using RabbitMQSender.Adapter.Payload;
using RabbitMQSender.Port;

var serviceCollection = new ServiceCollection();
ConfigureServices(serviceCollection);

var serviceProvider = serviceCollection.BuildServiceProvider();
var IMessager = serviceProvider.GetRequiredService<IMessager>();

while (true)
{
    Console.WriteLine("If you Want to Send a Message, just type 's' and click the enter button: \n");
    var character = Console.ReadLine();

    var guid = Guid.NewGuid();

    var message = new Message
    (
        141,
        "table_name",
        "Error test",
        "content",
        "service_test",
        DateTime.UtcNow
    );

    if (character.ToString().ToLower().Equals("s"))
        IMessager.SendMessage(message);
}

static void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IMessager, RabbitMQAdapter>();
}