using database.context.Models.Profile;
using database.context.Models.Profile.Languages;

namespace database.context.Repos.Profile
{
    public sealed class ProfileRepos : IProfileRepos
    {
        private readonly DataContext _db;

        public ProfileRepos(DataContext db) => _db = db;

        public UserBaseInfoModel? GetProfileBaseInfo(int id) => _db.ViewProfileBaseInfo
            .FirstOrDefault(user => user.ID == id);



        #region Языки

        public void AddLanguage(int userID, int languageID)
        {
            _db.TableProfileLanguages.Add(new(
                userID,
                languageID));
            _db.SaveChanges();
        }

        public LanguageModel? GetLanguageInfo(int id) => _db.TableProfileLanguages
            .FirstOrDefault(language => language.ID == id);

        public bool IsLanguageAdded(int userID, int languageID) => _db.TableProfileLanguages
            .FirstOrDefault(language => language.LanguageID == languageID && language.UserID == userID) is not null;

        public IEnumerable<ProfileLanguageModel>? GetLanguages(int userID) => _db.ViewProfileLanguages
            .Where(languages => languages.UserID == userID);

        #endregion



    }
}