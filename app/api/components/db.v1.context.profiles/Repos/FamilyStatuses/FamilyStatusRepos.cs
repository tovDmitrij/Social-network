using db.v1.context.profiles.Contexts.Interfaces;
using db.v1.context.profiles.Models.Dictionary;
namespace db.v1.context.profiles.Repos.FamilyStatuses
{
    /// <summary>
    /// Взаимодействие с таблицей семейных положений
    /// </summary>
    internal sealed class FamilyStatusRepos : IFamilyStatusRepos
    {
        /// <summary>
        /// База данных профилей пользователей
        /// </summary>
        private readonly IFamilyStatusContext _db;

        public FamilyStatusRepos(IFamilyStatusContext db) => _db = db;

        public bool IsStatusExist(int statusID) => _db.TableFamilyStatuses
            .Any(status => status.ID == statusID);

        public FamilyStatusModel? GetStatus(int statusID) => _db.TableFamilyStatuses
            .FirstOrDefault(status => status.ID == statusID);

        public IEnumerable<FamilyStatusModel>? GetStatuses() => _db.TableFamilyStatuses
            .Select(status => status);
    }
}