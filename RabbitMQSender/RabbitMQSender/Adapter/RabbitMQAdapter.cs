using RabbitMQSender.Port;
using RabbitMQ.Client;
using System.Security.Authentication;
using System.Net.Security;
using System.Text;
using RabbitMQSender.Adapter.Payload;
using Newtonsoft.Json;

namespace RabbitMQSender.Adapter;
public class RabbitMQAdapter : IMessager
{

    ConnectionFactory _factory;
    string _exchangeName;
    IConnection _connection;
    IModel _channel;

    public RabbitMQAdapter()
    {
        _factory = new ConnectionFactory
        {
            HostName = "b-30f49691-84f2-4f78-8d95-2e3a8053d234.mq.us-east-1.amazonaws.com",
            UserName = "ilegradev",
            Password = "MbjNY8tp",
            VirtualHost = "customer-data-ingestion",
            Port = 5671,
            Ssl = new SslOption
            {
                Enabled = true,
                Version = SslProtocols.Tls12,
                AcceptablePolicyErrors =
                                SslPolicyErrors.RemoteCertificateNameMismatch |
                                SslPolicyErrors.RemoteCertificateChainErrors |
                                SslPolicyErrors.None
            }

        };
        _exchangeName = "customer-data-ingestion";
        Create();
    }

    public void Create()
    {
        var queueName = "hospital-api-dead-letter";
        _connection = _factory.CreateConnection();
        _channel = _connection.CreateModel();
        
        _channel.QueueDeclare(
            queue: queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        _channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Fanout);

        _channel.QueueBind(queue: queueName,
                  exchange: _exchangeName,
                  routingKey: "");
    }

    public void SendMessage(Message content)
    {
        try
        {
            var json = JsonConvert.SerializeObject(content);
            var body = Encoding.UTF8.GetBytes(json);
            _channel.BasicPublish(exchange: _exchangeName,
                
                                 routingKey: "",
                                 basicProperties: null,
                                 body: body);
        }
        catch (Exception e)
        {
            Console.WriteLine($"\n {e.Message}");
        }
    }
}
        


