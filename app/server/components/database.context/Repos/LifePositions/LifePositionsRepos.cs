using database.context.Models.Data;
namespace database.context.Repos.LifePositions
{
    public sealed class LifePositionsRepos : BaseRepos, ILifePositionsRepos
    {
        public LifePositionsRepos(DataContext db) : base(db) { }

        public bool IsLifePositionExist(int positionID) => _db.TableLifePositions
            .Any(position => position.PositionID == positionID);

        public bool IsLifePositionExist(int typeID, int positionID) => _db.TableLifePositions
            .Any(position => position.TypeID == typeID && position.PositionID == positionID);

        public IEnumerable<LifePositionModel> GetLifePositions() => _db.TableLifePositions
            .Select(positions => positions);
    }
}