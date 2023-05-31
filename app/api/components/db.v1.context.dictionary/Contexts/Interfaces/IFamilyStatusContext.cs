using Microsoft.EntityFrameworkCore;
using db.v1.context.dictionary.Models;
namespace db.v1.context.dictionary.Contexts.Interfaces
{
    /// <summary>
    /// Контекст БД с таблицей семейных статусов
    /// </summary>
    internal interface IFamilyStatusContext
    {
        /// <summary>
        /// Таблица с информацией обо всех семейных положениях
        /// </summary>
        public DbSet<FamilyStatusModel> TableFamilyStatuses { get; set; }
    }
}