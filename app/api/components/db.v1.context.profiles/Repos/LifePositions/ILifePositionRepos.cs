using db.v1.context.profiles.Models.Dictionary;
namespace db.v1.context.profiles.Repos.LifePositions
{
    /// <summary>
    /// Взаимодействие с таблицей жизненных позиций
    /// </summary>
    public interface ILifePositionRepos
    {
        /// <summary>
        /// Метод, проверяющий существование жизненной позиции
        /// </summary>
        /// <param name="posID">Идентификатор позиции</param>
        public bool IsLifePositionExist(int posID);

        /// <summary>
        /// Метод, проверяющий существование типа жизненной позиции
        /// </summary>
        /// <param name="typeID">Идентификатор типа жизненной позиции</param>
        public bool IsLifePositionTypeExist(int typeID);

        /// <summary>
        /// Метод, проверяющий существование жизненной позиции
        /// </summary>
        /// <param name="typeID">Идентификатор типа позиции</param>
        /// <param name="posID">Идентификатор позиции</param>
        public bool IsLifePositionExist(int typeID, int posID);


        /// <summary>
        /// Получить информацию о жизненной позиции
        /// </summary>
        /// <param name="posID">Идентификатор позиции</param>
        public LifePositionModel? GetLifePosition(int posID);

        /// <summary>
        /// Получить список жизненных позиций
        /// </summary>
        public IEnumerable<LifePositionModel>? GetLifePositions();

        /// <summary>
        /// Получить список жизненных позиций
        /// </summary>
        /// <param name="typeID">Идентификатор типа жизненной позиции</param>
        public IEnumerable<LifePositionModel>? GetLifePositions(int typeID);
    }
}