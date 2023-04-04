using database.context.main.Models.Data;
namespace database.context.main.Repos.FamilyStatuses
{
    /// <summary>
    /// Взаимодействие с таблицей семейных положений
    /// </summary>
    public interface IFamilyStatusRepos
    {
        /// <summary>
        /// Метод, проверяющий существования семейного статуса по его идентификатору
        /// </summary>
        /// <param name="statusID">Идентификатор статуса</param>
        public bool IsStatusExist(int statusID);

        /// <summary>
        /// Получить информацию по семейному положению по его идентификатору
        /// </summary>
        /// <param name="statusID">Идентификатор статуса</param>
        public FamilyStatusModel? GetStatus(int statusID);

        /// <summary>
        /// Получить список семейных положений
        /// </summary>
        public IEnumerable<FamilyStatusModel>? GetStatuses();
    }
}