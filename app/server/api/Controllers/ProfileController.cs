using Microsoft.AspNetCore.Mvc;
using database.context.Repos.Profile;
using database.context.Repos.Languages;
using database.context.Repos.LifePositions;
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

        public ProfileController(IProfileRepos profile, ILanguageRepos language, ILifePositionsRepos lifePositions)
        {
            _profile = profile;
            _language = language;
            _position = lifePositions;
        }



        #region GET

        /// <summary>
        /// Получить базовую информацию о профиле пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("{userID:int}/BaseInfo/Get")]
        public IActionResult GetBaseProfileInfo(int userID) => _profile.IsUserExist(userID) ?
            ProfileBaseInfoOk(_profile.GetProfileBaseInfo(userID)) :
            UserNotFound;

        /// <summary>
        /// Получить список языков пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("{userID:int}/Languages/Get")]
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
        [HttpGet("{userID:int}/LifePositions/Get")]
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
        [HttpPost("{userID:int}/Language/Add/{langID:int}")]
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
        [HttpPost("{userID:int}/LifePosition/Add/{typeID:int}/{posID:int}")]
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

        [HttpPut("BaseInfo/Update/Status/{userID:int}")]
        public IActionResult UpdateBaseProfileInfo(int userID, string status)
        {
            //TODO
            return Ok();
        }

        [HttpPut("BaseInfo/Update/Avatar/{userID:int}")]
        public IActionResult UpdateBaseProfileInfo(int userID, byte[] avatar)
        {
            //TODO
            return Ok();
        }

        [HttpPut("BaseInfo/Update/{userID:int}")]
        public IActionResult UpdateBaseProfileInfo(int userID, string surname, string name, string patronymic, int cityID, int familyStatusID, DateTime birthDate)
        {
            //TODO
            return Ok();
        }

        #endregion



        #region DELETE

        /// <summary>
        /// Удалить из профиля пользователя некоторый язык
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="langID">Идентификатор языка</param>
        [HttpDelete("{userID:int}/Language/Delete/{langID:int}")]
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
        [HttpDelete("{userID:int}/LifePosition/Delete/{typeID:int}/{posID:int}")]
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