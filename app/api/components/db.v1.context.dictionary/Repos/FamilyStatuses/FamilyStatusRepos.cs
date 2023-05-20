using db.v1.context.dictionary.Models;
namespace db.v1.context.dictionary.Repos.FamilyStatuses
{
    /// <summary>
    /// Взаимодействие с таблицей семейных положений
    /// </summary>
    internal sealed class FamilyStatusRepos : IFamilyStatusRepos
    {
        /// <summary>
        /// База данных словаря
        /// </summary>
        private readonly DictionaryContext _db;

        public FamilyStatusRepos(DictionaryContext db) => _db = db;

        public bool IsStatusExist(int statusID) => _db.TableFamilyStatuses
            .Any(status => status.ID == statusID);

        public FamilyStatusModel? GetStatus(int statusID) => _db.TableFamilyStatuses
            .FirstOrDefault(status => status.ID == statusID);

        public IEnumerable<FamilyStatusModel>? GetStatuses() => _db.TableFamilyStatuses
            .Select(status => status);
    }
}