namespace Shared.Interfaces;

public interface IMessageBus
{
    Task PublishAsync<T>(string exchange, string routingKey, T message) where T : class;
    Task SubscribeAsync<T>(string queueName, string exchange, string routingKey, Func<T, Task> handler) where T : class;
}
