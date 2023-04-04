using System.Text;
using Microsoft.AspNetCore.Mvc;
using database.context.main.Repos.Profile;
using database.context.main.Repos.Languages;
using database.context.main.Repos.LifePositions;
using database.context.main.Repos.Cities;
using database.context.main.Repos.FamilyStatuses;
namespace api.Controllers
{
    /// <summary>
    /// Взаимодействие с профилем пользователей
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public sealed class ProfileController : BaseController
    {
        /// <summary>
        /// Взаимодействие с профилями пользователей
        /// </summary>
        private readonly IProfileRepos _profile;

        /// <summary>
        /// Взаимодействие с таблицей языков
        /// </summary>
        private readonly ILanguageRepos _language;

        /// <summary>
        /// Взаимодействие с таблицей жизненных позиций
        /// </summary>
        private readonly ILifePositionsRepos _position;

        /// <summary>
        /// Взаимодействие с таблицей мест проживания
        /// </summary>
        private readonly IPlaceOfLivingRepos _place;

        private readonly IFamilyStatusRepos _status;

        public ProfileController(
            IProfileRepos profile, 
            ILanguageRepos language, 
            ILifePositionsRepos lifePositions, 
            IPlaceOfLivingRepos place,
            IFamilyStatusRepos status)
        {
            _profile = profile;
            _language = language;
            _position = lifePositions;
            _place = place;
            _status = status;
        }



        #region GET

        /// <summary>
        /// Получить базовую информацию о профиле пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("userID={userID:int}/BaseInfo/Get")]
        public IActionResult GetBaseProfileInfo(int userID) => _profile.IsUserExist(userID) ?
            ProfileBaseInfoOk(_profile.GetProfileBaseInfo(userID)) :
            UserNotFound;

        /// <summary>
        /// Получить список языков пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("userID={userID:int}/Languages/Get")]
        public IActionResult GetLanguageInfo(int userID)
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;

            var languages = _profile.GetLanguages(userID);
            return languages.Any() ?
                ProfileLanguagesOk(languages) :
                ProfileLanguagesNotFound;
        }

        /// <summary>
        /// Получить список жизненных позиций пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("userID={userID:int}/LifePositions/Get")]
        public IActionResult GetLifePositionsInfo(int userID) 
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;
            
            var positions = _profile.GetLifePositions(userID);
            return positions.Any() ?
                ProfileLifePositionsOk(positions) :
                ProfileLifePositionsNotFound;
        }

        #endregion



        #region POST

        /// <summary>
        /// Добавить язык в список языков пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="langID">Идентификатор языка</param>
        [HttpPost("userID={userID:int}/Language/Add/langID={langID:int}")]
        public IActionResult AddLanguage(int userID, int langID)
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;
            if (!_language.IsLanguageExist(langID)) return LanguageNotFound;
            if (_profile.IsLanguageAdded(userID, langID)) return ProfileLanguageNotAcceptable;

            _profile.AddLanguage(userID, langID);
            return ProfileLanguageAddOk;
        }

        /// <summary>
        /// Добавить жизненную позицию (ЖП) в список ЖП пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="typeID">Идентификатор типа ЖП</param>
        /// <param name="posID">Идентификатор ЖП</param>
        [HttpPost("userID={userID:int}/LifePosition/Add/typeID={typeID:int}&posID={posID:int}")]
        public IActionResult AddLifePosition(int userID, int typeID, int posID)
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;
            if (!_position.IsLifePositionExist(typeID, posID)) return LifePositionByTypeNotFound;
            if (_profile.IsPositionTypeAdded(userID, typeID)) _profile.RemoveLifePositionType(userID, typeID);

            _profile.AddLifePosition(userID, posID);
            return ProfileLifePositionAddOk;
        }

        #endregion



        #region PUT

        /// <summary>
        /// Обновить статус в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="status">Статус пользователя</param>
        [HttpPut("userID={userID:int}/BaseInfo/Status/Update/status={status}")]
        public IActionResult UpdateProfileStatus(int userID, string status)
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;

            _profile.ChangeStatus(userID, status);
            return ProfileStatusUpdateOk;
        }

        /// <summary>
        /// Обновить аватар в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентфикатор пользователя</param>
        /// <param name="avatar">Аватарка</param>
        [HttpPut("userID={userID:int}/BaseInfo/Avatar/Update/avatar={avatar}")]
        public IActionResult UpdateProfileAvatar(int userID, string avatar)
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;

            _profile.ChangeAvatar(userID, Encoding.UTF8.GetBytes(avatar));
            return ProfileAvatarUpdateOK;
        }

        /// <summary>
        /// Обновить город в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="cityID">Идентификатор города</param>
        [HttpPut("userID={userID:int}/BaseInfo/City/Update/cityID={cityID:int}")]
        public IActionResult UpdateProfileCity(int userID, int cityID) 
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;
            if (!_place.IsCityExist(cityID)) return CityNotFound;

            _profile.ChangeCity(userID, cityID);
            return ProfileCityUpdateOK;
        }

        /// <summary>
        /// Обновить информацию о семейном положении в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="statusID">Идентификатор статуса</param>
        [HttpPut("userID={userID:int}/BaseInfo/FamilyStatus/Update/statusID={statusID:int}")]
        public IActionResult UpdateProfileFamilyStatus(int userID, int statusID) 
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;
            if (!_status.IsStatusExist(statusID)) return FamilyStatusNotFound;

            _profile.ChangeFamilyStatus(userID, statusID);
            return ProfileStatusUpdateOk;
        }

        /// <summary>
        /// Обновить дату рождения в профиел пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="date">Дата рождения</param>
        [HttpPut("userID={userID:int}/BaseInfo/Birthdate/Update/date={date:datetime}")]
        public IActionResult UpdateProfileBirthdate(int userID, DateTime date)
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;

            _profile.ChangeBirthDate(userID, date);
            return ProfileBirthdateUpdateOk;
        }

        /// <summary>
        /// Обновить ФИО в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        [HttpPut("userID={userID:int}/BaseInfo/Fullname/Update/surname={surname}&name={name}&patronymic={patronymic}")]
        public IActionResult UpdateProfileFullname(int userID, string surname, string name, string? patronymic)
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;

            _profile.ChangeFullname(userID, surname, name, patronymic);
            return ProfileFullnameUpdateOK;
        }

        #endregion



        #region DELETE

        /// <summary>
        /// Удалить из профиля пользователя некоторый язык
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="langID">Идентификатор языка</param>
        [HttpDelete("userID={userID:int}/Language/Delete/langID={langID:int}")]
        public IActionResult RemoveLanguage(int userID, int langID)
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;
            if (!_language.IsLanguageExist(langID)) return LanguageNotFound;
            if (!_profile.IsLanguageAdded(userID, langID)) return ProfileLanguageNotFound;

            _profile.RemoveLanguage(userID, langID);
            return ProfileLanguageDeleteOk;
        }

        /// <summary>
        /// Удалить из профиля пользователя некоторую жизненную позицию
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="typeID">Идентификатор категории жизненной позиции</param>
        /// <param name="posID">Идентификатор жизненной позиции</param>
        [HttpDelete("userID={userID:int}/LifePosition/Delete/typeID={typeID:int}&posID={posID:int}")]
        public IActionResult RemoveLifePosition(int userID, int typeID, int posID)
        {
            if (!_profile.IsUserExist(userID)) return UserNotFound;
            if (!_position.IsLifePositionExist(typeID, posID)) return LifePositionByTypeNotFound;
            if (!_profile.IsPositionAdded(userID, posID)) return LifePositionNotFound;

            _profile.RemoveLifePosition(userID, posID);
            return ProfileLifePositionDeleteOk;
        }

        #endregion



    }
}