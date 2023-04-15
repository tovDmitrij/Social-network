﻿using database.context.main.Models.Profile.BaseInfo;
using database.context.main.Models.Profile.Careers;
using database.context.main.Models.Profile.Languages;
using database.context.main.Models.Profile.LifePositions;
using database.context.main.Models.Profile.MilitaryServices;
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

        public void ChangeFullname(int userID, string surname, string name, string patronymic)
        {
            var user = _db.TableProfileBaseInfo.Single(user => user.UserID == userID);
            user.Surname = surname;
            user.Name = name;
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
            _db.TableProfileLanguages.Add(new(userID, langID));
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
            _db.TableProfileLifePositions.Add(new(userID, posID));
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