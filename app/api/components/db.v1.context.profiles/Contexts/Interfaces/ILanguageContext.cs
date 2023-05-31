using Microsoft.EntityFrameworkCore;
using db.v1.context.profiles.Models.Dictionary;
namespace db.v1.context.profiles.Contexts.Interfaces
{
    /// <summary>
    /// Контекст БД с таблицей языков
    /// </summary>
    internal interface ILanguageContext
    {
        /// <summary>
        /// Таблица с информацией обо всех языках
        /// </summary>
        public DbSet<LanguageModel> TableLanguages { get; set; }
    }
}