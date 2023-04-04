using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using database.context.Contexts;
using database.context.Models.Data;
using database.context.Repos.Logger;
namespace api.logger
{
    internal class Program
    {
        private static ILoggerRepos _logger;
        static void Main(string[] args)
        {
            using (LoggerContext db = new LoggerContext())
            {
                _logger = new LoggerRepos(db);
                var factory = new ConnectionFactory() { HostName = "localhost" };
                using (var connection = factory.CreateConnection())
                {
                    using (var channel = connection.CreateModel())
                    {
                        const string exchangeName = "direct_logs";
                        channel.ExchangeDeclare(
                            exchange: "direct_logs",
                            type: ExchangeType.Direct);

                        string queueName = channel.QueueDeclare().QueueName;
                        channel.QueueBind(
                            queue: queueName,
                            exchange: "direct_logs",
                            routingKey: "log");

                        var consumer = new EventingBasicConsumer(channel);
                        consumer.Received += (sender, args) =>
                        {
                            #nullable disable warnings
                            LogModel log = JsonSerializer.Deserialize<LogModel>(Encoding.UTF8.GetString(args.Body.ToArray()));
                            _logger.Log(log.Message, log.Source, log.StackTrace);
                        };

                        channel.BasicConsume(
                            queue: queueName,
                            autoAck: true,
                            consumer: consumer);

                        Console.ReadLine();
                    }
                }
            }

        }
    }
}