using database.context.Models.Profile;
using database.context.Models.Profile.Languages;
namespace database.context.Repos.Profile
{
    public sealed class ProfileRepos : BaseRepos, IProfileRepos
    {
        public ProfileRepos(DataContext db) : base(db) { }

        public ProfileBaseInfoModel? GetProfileBaseInfo(int id) => _db.ViewProfileBaseInfo
            .FirstOrDefault(user => user.ID == id);

        public bool IsUserExist(int id) => _db.TableUsers
            .Any(user => user.ID == id);



        #region Языки

        public void AddLanguage(int userID, int languageID)
        {
            _db.TableProfileLanguages.Add(new(
                userID,
                languageID));
            _db.SaveChanges();
        }

        public void RemoveLanguage(int userID, int languageID)
        {
            _db.TableProfileLanguages.Remove(
                _db.TableProfileLanguages.First(language => 
                    language.LanguageID == languageID && language.UserID == userID));
            _db.SaveChanges();
        }

        public bool IsLanguageAdded(int userID, int languageID) => _db.TableProfileLanguages
           .Any(language => language.LanguageID == languageID && language.UserID == userID);

        public IEnumerable<ProfileLanguageInfoModel>? GetLanguages(int userID) => _db.ViewProfileLanguages
            .Where(languages => languages.UserID == userID);

        #endregion



    }
}