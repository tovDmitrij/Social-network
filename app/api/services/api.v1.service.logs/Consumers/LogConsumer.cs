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
        private readonly ILogRepos _logRepos;

        public LogConsumer(ILogRepos db) => _logRepos = db;

        /// <summary>
        /// Добавить новый лог в БД
        /// </summary>
        /// <param name="context">Информация об ошибке</param>
        public async Task Consume(ConsumeContext<LogModel> context) => _logRepos.Log(context.Message);
    }
}