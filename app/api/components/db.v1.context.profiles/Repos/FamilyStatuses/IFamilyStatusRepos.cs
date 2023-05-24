using db.v1.context.profiles.Models.Dictionary;
namespace db.v1.context.profiles.Repos.FamilyStatuses
{
    /// <summary>
    /// Взаимодействие с таблицей семейных положений
    /// </summary>
    public interface IFamilyStatusRepos
    {
        /// <summary>
        /// Метод, проверяющий существования семейного положения
        /// </summary>
        /// <param name="statusID">Идентификатор статуса</param>
        public bool IsStatusExist(int statusID);

        /// <summary>
        /// Получить информацию о семейном положении
        /// </summary>
        /// <param name="statusID">Идентификатор статуса</param>
        public FamilyStatusModel? GetStatus(int statusID);

        /// <summary>
        /// Получить список семейных положений
        /// </summary>
        public IEnumerable<FamilyStatusModel>? GetStatuses();
    }
}