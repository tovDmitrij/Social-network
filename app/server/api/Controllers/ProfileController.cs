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
    public sealed class ProfileController : ControllerBase
    {
        private readonly IProfileRepos _profile;
        private readonly ILanguageRepos _language;
        private readonly ILifePositionsRepos _lifePositions;
        public ProfileController(IProfileRepos profile, ILanguageRepos language, ILifePositionsRepos lifePositions)
        {
            _profile = profile;
            _language = language;
            _lifePositions = lifePositions;
        }



        #region GET

        /// <summary>
        /// Получить базовую информацию о профиле пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("BaseInfo/Get/{userID:int}")]
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
        [HttpGet("Languages/Get/{userID:int}")]
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
        [HttpGet("LifePositions/Get/{userID:int}")]
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
        [HttpPost("Languages/Add")]
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
        [HttpPost("LifePositions/Add")]
        public IActionResult AddLifePosition(int userID, int typeID, int posID)
        {
            if (!_profile.IsUserExist(userID))
            {
                return StatusCode(200, new { status = "Пользователя с заданным идентификатором не существует" });
            }
            if (!_lifePositions.IsLifePositionExist(typeID, posID))
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
        [HttpDelete("Languages/Delete")]
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
        [HttpDelete("LifePositions/Delete")]
        public IActionResult RemoveLifePosition(int userID, int typeID, int posID)
        {
            if (!_profile.IsUserExist(userID))
            {
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            }
            if (!_lifePositions.IsLifePositionExist(typeID, posID))
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