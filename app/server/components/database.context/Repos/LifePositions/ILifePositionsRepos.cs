using database.context.Models.Data;
namespace database.context.Repos.LifePositions
{
    /// <summary>
    /// Взаимодействие с таблицей жизненных позиций, определённых в системе
    /// </summary>
    public interface ILifePositionsRepos
    {
        /// <summary>
        /// Метод, проверяющий существование жизненной позиции по его идентификатору
        /// </summary>
        /// <param name="posID">Идентификатор позиции</param>
        public bool IsLifePositionExist(int posID);

        /// <summary>
        /// Метод, проверяющий существование типа жизненной позиции по её идентификатору
        /// </summary>
        /// <param name="typeID">Идентификатор типа жизненной позиции</param>
        public bool IsLifePositionTypeExist(int typeID);

        /// <summary>
        /// Метод, проверяющий существование жизненной позиции по его идентификатору и типу
        /// </summary>
        /// <param name="typeID">Идентификатор типа позиции</param>
        /// <param name="posID">Идентификатор позиции</param>
        public bool IsLifePositionExist(int typeID, int posID);


        /// <summary>
        /// Получить информацию о жизненной позиции по её идентификатору
        /// </summary>
        /// <param name="posID">Идентификатор позиции</param>
        public LifePositionModel? GetLifePosition(int posID);

        /// <summary>
        /// Получить список жизненных позиций
        /// </summary>
        public IEnumerable<LifePositionModel>? GetLifePositions();

        /// <summary>
        /// Получить список жизненных позиций (ЖП) по идентификатору типа ЖП
        /// </summary>
        /// <param name="typeID">Идентификатор типа ЖП</param>
        public IEnumerable<LifePositionModel>? GetLifePositions(int typeID);
    }
}