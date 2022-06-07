using RabbitMQSender.Adapter.Payload;

namespace RabbitMQSender.Port
{
    public interface IMessager
    {
        void SendMessage(Message content);
    }
}
