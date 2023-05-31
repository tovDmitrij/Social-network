using Microsoft.EntityFrameworkCore;
using db.v1.context.dictionary.Models;
namespace db.v1.context.dictionary.Contexts.Interfaces
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