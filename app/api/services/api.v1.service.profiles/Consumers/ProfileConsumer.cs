using MassTransit;
using db.v1.context.profiles.Models.Profiles.BaseInfo;
using db.v1.context.profiles.Wrappers;
namespace api.v1.service.profiles.Consumers
{
    /// <summary>
    /// Взаимодействие с сервисом профилей пользователей
    /// </summary>
    public sealed class ProfileConsumer: IConsumer<ProfileBaseInfoModel>
    {
        /// <summary>
        /// Взаимодействие с БД профилей пользователей
        /// </summary>
        private readonly IProfileWrapper _profWrapper;

        public ProfileConsumer(IProfileWrapper db) => _profWrapper = db;

        /// <summary>
        /// Добавить профиль нового пользователя
        /// </summary>
        /// <param name="context">Информация о профиле</param>
        public async Task Consume(ConsumeContext<ProfileBaseInfoModel> context)
        {
            var data = context.Message;
            _profWrapper.Profiles.AddProfile(data.UserID, data.Surname, data.Name, data.Patronymic);
        }
    }
}