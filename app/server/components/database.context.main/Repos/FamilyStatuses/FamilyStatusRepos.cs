using database.context.main.Models.Data;
namespace database.context.main.Repos.FamilyStatuses
{
    public sealed class FamilyStatusRepos : BaseRepos, IFamilyStatusRepos
    {
        public FamilyStatusRepos(MainContext db) : base(db) { }

        public bool IsStatusExist(int statusID) => _db.TableFamilyStatuses
            .Any(status => status.ID == statusID);

        public FamilyStatusModel? GetStatus(int statusID) => _db.TableFamilyStatuses
            .FirstOrDefault(status => status.ID == statusID);

        public IEnumerable<FamilyStatusModel>? GetStatuses() => _db.TableFamilyStatuses
            .Select(status => status);
    }
}