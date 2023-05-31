using Microsoft.EntityFrameworkCore;
using db.v1.context.dictionary.Models;
namespace db.v1.context.dictionary.Contexts.Interfaces
{
    /// <summary>
    /// Контекст БД с таблицей жизненных позиций
    /// </summary>
    internal interface ILifePositionContext
    {

        /// <summary>
        /// Представление с информацией обо всех жизненных позициях
        /// </summary>
        public DbSet<LifePositionModel> ViewLifePositions { get; set; }
    }
}