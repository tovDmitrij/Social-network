using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using database.context.logs;
using database.context.logs.Repos;
namespace api.logger.error
{
    internal class Program
    {
        /// <summary>
        /// Взаимодействие с таблицей логов в БД
        /// </summary>
        private static ILoggerRepos _logger;

        /// <summary>
        /// Массив цветов для чата
        /// </summary>
        private static readonly ConsoleColor[] _colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(ExitMessage);
            StartMessage();
            Connect();
        }

        /// <summary>
        /// Подключение к очереди сообщений логов
        /// </summary>
        private static void Connect()
        {
            try
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
                                routingKey: "error");

                            var consumer = new EventingBasicConsumer(channel);
                            consumer.Received += (sender, args) =>
                            {
                                _logger.Log(JsonSerializer.Deserialize<LogModel>(Encoding.UTF8.GetString(args.Body.ToArray())));
                                PrintMessage();
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
            catch (Exception ex)
            {
                ExitErrorMessage(ex);
            }
        }

        private static void StartMessage()
        {
            Console.ForegroundColor = _colors[4];
            Console.WriteLine("========================");
            Console.WriteLine("=== API.Logger.Error ===");
            Console.WriteLine("========================");
            Console.ResetColor();
        }
        
        private static void PrintMessage()
        {
            Console.ForegroundColor = _colors[7];
            Console.WriteLine($">>{DateTime.Now}\tНовый отчёт об ошибке готов и отправлен в БД");
            Console.ResetColor();
        }
        
        private static void ExitMessage(object sender, EventArgs e)
        {
            Console.ForegroundColor = _colors[11];
            Console.WriteLine(">>Работа логгера успешно завершена");
            Console.ResetColor();
        }

        private static void ExitErrorMessage(Exception ex) 
        {
            Console.ForegroundColor = _colors[11];
            Console.WriteLine($">>Работа логгера аварийно завершена по причине: {ex.Message}");
            Console.ResetColor();
        }
    }
}