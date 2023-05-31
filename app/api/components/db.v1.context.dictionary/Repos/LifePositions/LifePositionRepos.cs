using db.v1.context.dictionary.Contexts.Interfaces;
using db.v1.context.dictionary.Models;
namespace db.v1.context.dictionary.Repos.LifePositions
{
    /// <summary>
    /// Взаимодействие с таблицей жизненных позиций
    /// </summary>
    internal sealed class LifePositionRepos : ILifePositionRepos
    {
        /// <summary>
        /// База данных словаря
        /// </summary>
        private readonly ILifePositionContext _db;

        public LifePositionRepos(ILifePositionContext db) => _db = db;

        public bool IsLifePositionExist(int posID) => _db.ViewLifePositions
            .Any(pos => pos.PositionID == posID);

        public bool IsLifePositionExist(int typeID, int posID) => _db.ViewLifePositions
            .Any(pos => pos.TypeID == typeID && pos.PositionID == posID);

        public bool IsLifePositionTypeExist(int typeID) => _db.ViewLifePositions
            .Any(pos => pos.TypeID == typeID);

        public LifePositionModel? GetLifePosition(int posID) => _db.ViewLifePositions
            .FirstOrDefault(pos => pos.PositionID == posID);

        public IEnumerable<LifePositionModel>? GetLifePositions() => _db.ViewLifePositions
            .Select(pos => pos);

        public IEnumerable<LifePositionModel>? GetLifePositions(int typeID) => _db.ViewLifePositions
            .Where(pos => pos.TypeID == typeID);
    }
}