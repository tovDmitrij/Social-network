using database.context.main;
using database.context.main.Models.Profile.BaseInfo;
using database.context.main.Models.Profile.Languages;
using database.context.main.Models.Profile.LifePositions;
namespace database.context.main.Repos.Profile
{
    public sealed class ProfileRepos : BaseRepos, IProfileRepos
    {
        public ProfileRepos(MainContext db) : base(db) { }

        public bool IsUserExist(int id) => _db.TableUsers
            .Any(user => user.ID == id);



        #region Основная информация

        public ProfileBaseInfoViewModel? GetProfileBaseInfo(int id) => _db.ViewProfileBaseInfo
            .FirstOrDefault(user => user.ID == id);

        public void ChangeStatus(int userID, string status)
        {
            var user = _db.TableProfileBaseInfo.Single(user => user.UserID == userID);
            user.Status = status;
            _db.TableProfileBaseInfo.Update(user);
            _db.SaveChanges();
        }

        public void ChangeAvatar(int userID, byte[] avatar)
        {
            throw new NotImplementedException();
        }
        
        public void ChangeCity(int userID, int cityID)
        {
            throw new NotImplementedException();
        }

        public void ChangeFamilyStatus(int userID, int statusID)
        {
            throw new NotImplementedException();
        }

        public void ChangeBirthDate(int userID, DateTime date)
        {
            throw new NotImplementedException();
        }

        public void ChangeFullname(int userID, string surname, string name, string patronymic)
        {
            throw new NotImplementedException();
        }

        #endregion



        #region Языки

        public bool IsLanguageAdded(int userID, int langID) => _db.TableProfileLanguages
            .Any(language => language.LanguageID == langID && language.UserID == userID);

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

        public IEnumerable<ProfileLanguageViewModel>? GetLanguages(int userID) => _db.ViewProfileLanguages
            .Where(language => language.UserID == userID);

        #endregion



        #region Жизненные позиции

        public bool IsPositionTypeAdded(int userID, int typeID) => _db.ViewProfileLifePositions
            .Any(position => position.TypeID == typeID && position.UserID == userID);

        public bool IsPositionAdded(int userID, int posID) => _db.ViewProfileLifePositions
            .Any(position => position.PositionID == posID && position.UserID == userID);

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

        public IEnumerable<ProfileLifePositionViewModel>? GetLifePositions(int userID) => _db.ViewProfileLifePositions
            .Where(position => position.UserID == userID);

        #endregion



    }
}