using database.context.Models.Profile;
using database.context.Models.Profile.Languages;
using database.context.Models.Profile.LifePositions;
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

        public void AddLanguage(int userID, int langID)
        {
            _db.TableProfileLanguages.Add(new(
                userID,
                langID));
            _db.SaveChanges();
        }

        public void RemoveLanguage(int userID, int langID)
        {
            _db.TableProfileLanguages.Remove(
                _db.TableProfileLanguages.First(language => 
                    language.LanguageID == langID && language.UserID == userID));
            _db.SaveChanges();
        }

        public bool IsLanguageAdded(int userID, int langID) => _db.TableProfileLanguages
           .Any(language => language.LanguageID == langID && language.UserID == userID);

        public IEnumerable<ProfileLanguageInfoModel>? GetLanguages(int userID) => _db.ViewProfileLanguages
            .Where(languages => languages.UserID == userID);

        #endregion



        #region Жизненные позиции

        public void AddLifePosition(int userID, int posID)
        {
            _db.TableProfileLifePositions.Add(new(
                userID, 
                posID));
            _db.SaveChanges();
        }

        public void RemoveLifePosition(int userID, int posID)
        {
            _db.TableProfileLifePositions.Remove(
                _db.TableProfileLifePositions.First(position => 
                    position.UserID == userID && position.PositionID == posID));
            _db.SaveChanges();
        }

        public void RemoveLifePositionType(int userID, int typeID)
        {
            _db.TableProfileLifePositions.Remove(
                _db.TableProfileLifePositions.First(position =>
                    position.UserID == userID && position.PositionID == _db.ViewProfileLifePositions.First(position =>
                        position.UserID == userID && position.TypeID == typeID).PositionID));
            _db.SaveChanges();
        }

        public bool IsPositionTypeAdded(int userID, int typeID) => _db.ViewProfileLifePositions
            .Any(position => position.TypeID == typeID && position.UserID == userID);

        public bool IsPositionAdded(int userID, int posID) => _db.ViewProfileLifePositions
            .Any(position => position.PositionID == posID && position.UserID == userID);

        public IEnumerable<ProfileLifePositionsInfoModel>? GetLifePositions(int userID) => _db.ViewProfileLifePositions
            .Where(positions => positions.UserID == userID);

        #endregion



    }
}