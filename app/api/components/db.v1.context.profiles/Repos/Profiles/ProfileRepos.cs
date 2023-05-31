using db.v1.context.profiles.Contexts.Interfaces;
using db.v1.context.profiles.Models.Profiles.BaseInfo;
using db.v1.context.profiles.Models.Profiles.Carrers;
using db.v1.context.profiles.Models.Profiles.Languages;
using db.v1.context.profiles.Models.Profiles.LifePositions;
using db.v1.context.profiles.Models.Profiles.MilitaryServices;
namespace db.v1.context.profiles.Repos.Profiles
{
    /// <summary>
    /// Взаимодействие с профилем пользователей
    /// </summary>
    public sealed class ProfileRepos : IProfileRepos
    {
        /// <summary>
        /// База данных профилей пользователей
        /// </summary>
        private readonly IProfileContext _db;

        public ProfileRepos(IProfileContext db) => _db = db;



        #region Основная информация

        public void AddProfile(int userID, string surname, string name, string? patronymic)
        {
            _db.TableProfileBaseInfo.Add(new(userID, surname, name, patronymic));
            _db.SaveChanges();
        }

        public bool IsProfileExist(int id) => _db.TableProfileBaseInfo
            .Any(profile => profile.UserID == id);

        public ProfileBaseInfoViewModel? GetProfileBaseInfo(int id) => _db.ViewProfileBaseInfo
            .FirstOrDefault(user => user.UserID == id);

        public void ChangeStatus(int userID, string status)
        {
            var user = _db.TableProfileBaseInfo.Single(user => user.UserID == userID);
            user.Status = status;
            _db.TableProfileBaseInfo.Update(user);
            _db.SaveChanges();
        }

        public void ChangeAvatar(int userID, string avatar)
        {
            var user = _db.TableProfileBaseInfo.Single(user => user.UserID == userID);
            user.Avatar = avatar;
            _db.TableProfileBaseInfo.Update(user);
            _db.SaveChanges();
        }

        public void ChangeCity(int userID, int cityID)
        {
            var user = _db.TableProfileBaseInfo.Single(user => user.UserID == userID);
            user.CityID = cityID;
            _db.TableProfileBaseInfo.Update(user);
            _db.SaveChanges();
        }

        public void ChangeFamilyStatus(int userID, int statusID)
        {
            var user = _db.TableProfileBaseInfo.Single(user => user.UserID == userID);
            user.FamilyStatusID = statusID;
            _db.TableProfileBaseInfo.Update(user);
            _db.SaveChanges();
        }

        public void ChangeBirthDate(int userID, DateTime date)
        {
            var user = _db.TableProfileBaseInfo.Single(user => user.UserID == userID);
            user.BirthDate = date;
            _db.TableProfileBaseInfo.Update(user);
            _db.SaveChanges();
        }

        public void ChangeSurname(int userID, string surname)
        {
            var user = _db.TableProfileBaseInfo.Single(user => user.UserID == userID);
            user.Surname = surname;
            _db.TableProfileBaseInfo.Update(user);
            _db.SaveChanges();
        }

        public void ChangeName(int userID, string name)
        {
            var user = _db.TableProfileBaseInfo.Single(user => user.UserID == userID);
            user.Name = name;
            _db.TableProfileBaseInfo.Update(user);
            _db.SaveChanges();
        }

        public void ChangePatronymic(int userID, string patronymic)
        {
            var user = _db.TableProfileBaseInfo.Single(user => user.UserID == userID);
            user.Patronymic = patronymic;
            _db.TableProfileBaseInfo.Update(user);
            _db.SaveChanges();
        }

        #endregion



        #region Языки

        public bool IsLanguageAdded(int userID, int langID) => _db.TableProfileLanguages
            .Any(language => language.LanguageID == langID && language.UserID == userID);

        public void AddLanguage(int userID, int langID)
        {
            DateTime date = DateTime.Now;
            _db.TableProfileLanguages.Add(new(userID, langID, date));
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
            DateTime date = DateTime.Now;
            _db.TableProfileLifePositions.Add(new(userID, posID, date));
            _db.SaveChanges();
        }

        public void RemoveLifePosition(int userID, int posID)
        {
            _db.TableProfileLifePositions.Remove(
                _db.TableProfileLifePositions.Single(position =>
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



        #region Карьера

        public void AddCarrer(int userID, int cityID, string company, string? job, DateTime? dateFrom, DateTime? dateTo)
        {
            _db.TableProfileCarrer.Add(new(userID, cityID, company, job, dateFrom, dateTo));
            _db.SaveChanges();
        }

        public void UpdateCarrer(int carrerID, int cityID, string company, string? job, DateTime? dateFrom, DateTime? dateTo)
        {
            var carrer = _db.TableProfileCarrer.Single(carrer => carrer.ID == carrerID);
            carrer.CityID = cityID;
            carrer.Company = company;
            carrer.Job = job;
            carrer.DateFrom = dateFrom;
            carrer.DateTo = dateTo;
            _db.TableProfileCarrer.Update(carrer);
            _db.SaveChanges();
        }

        public void RemoveCarrer(int userID, int carrerID)
        {
            _db.TableProfileCarrer.Remove(_db.TableProfileCarrer
                .First(carrer =>
                    carrer.UserID == userID && carrer.ID == carrerID));
            _db.SaveChanges();
        }

        public bool IsCarrerAdded(int userID, int carrerID) => _db.TableProfileCarrer
            .Any(carrer => carrer.UserID == userID && carrer.ID == carrerID);

        public bool IsCarrerAdded(int userID, int cityID, string company, string? job, DateTime? dateFrom, DateTime? dateTo) => _db.TableProfileCarrer
            .Any(c => c.UserID == userID && c.CityID == cityID && c.Company == company && c.Job == job && c.DateFrom == dateFrom && c.DateTo == dateTo);

        public IEnumerable<ProfileCarrerViewModel>? GetCarrers(int userID) => _db.ViewProfileCarrer
            .Where(carrer => carrer.UserID == userID);

        #endregion



        #region Военная служба

        public void AddMilitaryService(int userID, int countryID, string militaryUnit, DateTime? dateFrom, DateTime? dateTo)
        {
            _db.TableProfileMilitaryService.Add(new(
                userID,
                countryID,
                militaryUnit,
                dateFrom,
                dateTo));
            _db.SaveChanges();
        }

        public void UpdateMilitaryService(int serviceID, int countryID, string militaryUnit, DateTime? dateFrom, DateTime? dateTo)
        {
            var service = _db.TableProfileMilitaryService.Single(service => service.ID == serviceID);
            service.CountryID = countryID;
            service.MilitaryUnit = militaryUnit;
            service.DateFrom = dateFrom;
            service.DateTo = dateTo;
            _db.TableProfileMilitaryService.Update(service);
            _db.SaveChanges();
        }

        public void RemoveMilitaryService(int userID, int serviceID)
        {
            _db.TableProfileMilitaryService.Remove(_db.TableProfileMilitaryService
                .Single(service => service.UserID == userID && service.ID == serviceID));
            _db.SaveChanges();
        }

        public bool IsMilitaryServiceAdded(int userID, int serviceID) => _db.TableProfileMilitaryService
            .Any(service => service.UserID == userID && service.ID == serviceID);

        public bool IsMilitaryServiceAdded(int userID, int countryID, string militaryUnit, DateTime? dateFrom, DateTime? dateTo) => _db.TableProfileMilitaryService
            .Any(s => s.UserID == userID && s.CountryID == countryID && s.MilitaryUnit == militaryUnit && s.DateFrom == dateFrom && s.DateTo == dateTo);

        public IEnumerable<ProfileMilitaryServiceViewModel>? GetMilitaryServices(int userID) => _db.ViewProfileMilitaryService
            .Where(service => service.UserID == userID);

        #endregion



    }
}