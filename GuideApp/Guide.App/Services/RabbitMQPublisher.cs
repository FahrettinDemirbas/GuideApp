using System.Text.Json;
using System.Text;
using RabbitMQ.Client;

namespace Guide.App.Services
{
    public class RabbitMQPublisher
    {
        private readonly RabbitMQClientService _rabbitmqClientService;
        public RabbitMQPublisher(RabbitMQClientService rabbitmqClientService)
        {
            _rabbitmqClientService = rabbitmqClientService;
        }

        public void Publish(GuideReportCreatedEvent guideReportCreatedEvent)
        {
            var channel = _rabbitmqClientService.Connect();
            var bodyString = JsonSerializer.Serialize(guideReportCreatedEvent);
            var bodyByte = Encoding.UTF8.GetBytes(bodyString);
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            channel.BasicPublish(
                    exchange: RabbitMQClientService.ExchangeName,
                    routingKey: RabbitMQClientService.RoutingGuide,
                    basicProperties: properties,
                    body: bodyByte);

        }
    }
}
