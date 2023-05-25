using MassTransit;
using db.v1.context.logs.Models;
using db.v1.context.logs.Repos;
namespace api.v1.service.logs.Consumers
{
    /// <summary>
    /// Взаимодействие с сервисом логирования ошибок
    /// </summary>
    public sealed class LogConsumer : IConsumer<LogModel>
    {
        /// <summary>
        /// Взаимодействие с таблицей логов в БД
        /// </summary>
        private readonly ILogRepos _db;

        public LogConsumer(ILogRepos db) => _db = db;

        /// <summary>
        /// Добавить новый лог в БД
        /// </summary>
        /// <param name="context">Информация об ошибке</param>
        public async Task Consume(ConsumeContext<LogModel> context) => _db.Log(context.Message);
    }
}