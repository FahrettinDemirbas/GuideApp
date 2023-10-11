using RabbitMQ.Client;

namespace Guide.App.Services
{
    public class RabbitMQClientService : IDisposable
    {
        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        public static string ExchangeName = "ReportDirectExchange";
        public static string RoutingGuide = "Guide-route-report";
        public static string QueueName = "queue-guide-report";

        public RabbitMQClientService(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;  
        }

        public IModel Connect()
        {
            _connection = _connectionFactory.CreateConnection();
            if (_channel is { IsOpen: true })
            {
                return _channel;
            }

            _channel = _connection.CreateModel();
            bool durable = true;
            bool autoDelete = false;
            _channel.ExchangeDeclare(ExchangeName, type: "direct", durable, autoDelete);
            bool exclusive = false;
            _channel.QueueDeclare(QueueName, durable, exclusive, autoDelete, null);
            _channel.QueueBind(exchange: ExchangeName, queue: QueueName, routingKey: RoutingGuide);  

            return _channel;
        }

        public void Dispose()
        {
            _channel?.Close();
            _channel?.Dispose();
            _connection?.Close();
            _connection?.Dispose();                                     
        }
    }
}
