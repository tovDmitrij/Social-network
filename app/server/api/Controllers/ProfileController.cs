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
        public IActionResult GetBaseProfileInfo(int userID)
        {
            switch (_profile.IsUserExist(userID))
            {
                case true:
                    return StatusCode(200, new
                        {
                            status = "Базовая информация о пользователе была успешно сформирована",
                            user = _profile.GetProfileBaseInfo(userID)
                        });

                case false:
                    return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            }
        }

        /// <summary>
        /// Получить список языков пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("{userID:int}/Languages/Get")]
        public IActionResult GetLanguageInfo(int userID)
        {
            if (!_profile.IsUserExist(userID))
            {
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            }

            var languages = _profile.GetLanguages(userID);
            switch (languages.Any())
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Список языков пользователя успешно сформирован",
                        data = languages
                    });

                case false:
                    return StatusCode(404, new { status = "У пользователя отсутствует список языков" });
            }
        }

        /// <summary>
        /// Получить список жизненных позиций пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("{userID:int}/LifePositions/Get")]
        public IActionResult GetLifePositionsInfo(int userID) 
        {
            if (!_profile.IsUserExist(userID))
            {
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            }

            var positions = _profile.GetLifePositions(userID);
            switch (positions.Any())
            {
                case true:
                    return StatusCode(200, new
                    {
                        status = "Список жизненных позиций был успешно сформирован",
                        data = positions
                    });

                case false:
                    return StatusCode(404, new { status = "У пользователя отсутствует список жизненных позиций" });
            }
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
            if (!_profile.IsUserExist(userID))
            {
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            }
            if (!_language.IsLanguageExist(langID))
            {
                return StatusCode(404, new { status = "Языка с заданным идентификатором не существует" });
            }
            if (_profile.IsLanguageAdded(userID, langID))
            {
                return StatusCode(406, new { status = "Язык уже добавлен в список языков пользователя" });
            }

            _profile.AddLanguage(userID, langID);
            return StatusCode(200, new { status = "Новый язык был успешно добавлен в профиль пользователя" });
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
            if (!_profile.IsUserExist(userID))
            {
                return StatusCode(200, new { status = "Пользователя с заданным идентификатором не существует" });
            }
            if (!_position.IsLifePositionExist(typeID, posID))
            {
                return StatusCode(404, new { status = "Жизненной позиции с заданными параметрами не существует" });
            }
            if (_profile.IsPositionTypeAdded(userID, typeID))
            {
                _profile.RemoveLifePositionType(userID, typeID);
                //return StatusCode(406, new { status = "Жизненная позиция в заданной категории уже добавлена" });
            }

            _profile.AddLifePosition(userID, posID);
            return StatusCode(200, new { status = "Новая жизненная позиция была успешно добавлена" });
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
            if (!_profile.IsUserExist(userID))
            {
                return StatusCode(404, new { status = "Пользователь с заданным идентификатором не найден" });
            }
            if (!_language.IsLanguageExist(langID))
            {
                return StatusCode(404, new { status = "Языка с заданным идентификатором не существует в системе" });
            }
            if (!_profile.IsLanguageAdded(userID, langID))
            {
                return StatusCode(406, new { status = "Языка нет в списке языков пользователя" });
            }

            _profile.RemoveLanguage(userID, langID);
            return StatusCode(200, new { status = "Удаление языка из профиля пользователя прошло успешно" });
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
            if (!_profile.IsUserExist(userID))
            {
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            }
            if (!_position.IsLifePositionExist(typeID, posID))
            {
                return StatusCode(404, new { status = "Жизненной позиции с заданными параметрами не существует" });
            }
            if (!_profile.IsPositionAdded(userID, posID))
            {
                return StatusCode(406, new { status = "Жизненная позиция c заданными параметрами отсутствует в списке пользователя" });
            }

            _profile.RemoveLifePosition(userID, posID);
            return StatusCode(200, new { status = "Удаление жизненной позиции прошло успешно" });
        }

        #endregion



    }
}