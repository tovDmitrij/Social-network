using database.context.Models.Data;
namespace database.context.Repos.LifePositions
{
    public sealed class LifePositionsRepos : BaseRepos, ILifePositionsRepos
    {
        public LifePositionsRepos(DataContext db) : base(db) { }

        public bool IsLifePositionExist(int posID) => _db.ViewLifePositions
            .Any(position => position.PositionID == posID);

        public bool IsLifePositionExist(int typeID, int posID) => _db.ViewLifePositions
            .Any(position => position.TypeID == typeID && position.PositionID == posID);

        public bool IsLifePositionTypeExist(int typeID) => _db.ViewLifePositions
            .Any(position => position.TypeID == typeID);

        public LifePositionModel? GetLifePosition(int posID) => _db.ViewLifePositions
            .Single(position => position.PositionID == posID);

        public IEnumerable<LifePositionModel>? GetLifePositions() => _db.ViewLifePositions
            .Select(positions => positions);

        public IEnumerable<LifePositionModel>? GetLifePositions(int typeID) => _db.ViewLifePositions
            .Where(positions => positions.TypeID == typeID);
    }
}