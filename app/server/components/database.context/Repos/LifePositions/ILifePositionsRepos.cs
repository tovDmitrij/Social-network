using database.context.Models.Data;
namespace database.context.Repos.LifePositions
{
    /// <summary>
    /// Взаимодействие с таблицей жизненных позиций, определённых в системе
    /// </summary>
    public interface ILifePositionsRepos
    {
        /// <summary>
        /// Метод, проверяющий существование жизненной позиции с заданным идентификатором
        /// </summary>
        /// <param name="positionID">Идентификатор позиции</param>
        public bool IsLifePositionExist(int positionID);

        /// <summary>
        /// Метод, проверяющий существование жизненной позиции по его идентификатору и типу
        /// </summary>
        /// <param name="positionTypeID">Идентификатор типа позиции</param>
        /// <param name="positionID">Идентификатор позиции</param>
        public bool IsLifePositionExist(int positionTypeID, int positionID);

        /// <summary>
        /// Получить список жизненных позиций
        /// </summary>
        public IEnumerable<LifePositionModel> GetLifePositions();
    }
}