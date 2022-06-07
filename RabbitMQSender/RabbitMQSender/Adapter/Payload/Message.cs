namespace RabbitMQSender.Adapter.Payload
{
    public record Message(
      int ProjectId,
      string TableName,
      string ErrorMessage,
      string Content,
      string ServiceName,
      DateTime OcurredAt
    );
}
