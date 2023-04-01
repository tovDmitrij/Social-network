using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using database.context.Repos.Profile;
using database.context.Models.Profile;
using database.context.Models.Profile.Languages;
namespace api.Controllers
{
    /// <summary>
    /// Взаимодействие с профилем пользователей
    /// </summary>
    [ApiController]
    //[Authorize]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepos _profile;

        public ProfileController(IProfileRepos db) => _profile = db;



        #region GET

        /// <summary>
        /// Получить базовую информацию о профиле пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("Base/{userID:int}")]
        public IActionResult GetBaseProfileInfo(int userID)
        {
            UserBaseInfoModel? user = _profile.GetProfileBaseInfo(userID);

            switch (user is null)
            {
                case true:
                    return StatusCode(404,
                    new
                    {
                        status = "Пользователя с заданным идентификатором не существует"
                    });
                case false:
                    return StatusCode(200,
                        new
                        {
                            status = "Пользователь успешно найден",
                            user
                        });
            }
        }

        /// <summary>
        /// Получить список языков пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("Languages/{userID:int}")]
        public IActionResult GetLanguageList(int userID)
        {
            UserBaseInfoModel? user = _profile.GetProfileBaseInfo(userID);

            switch (user is null)
            {
                case true:
                    return StatusCode(404,
                        new 
                        {
                            status = "Пользователя с заданным идентификатором не существует"
                        });
                case false:
                    IEnumerable<ProfileLanguageModel>? languages = _profile.GetLanguages(userID);

                    switch (languages is not null)
                    { 
                        case true:
                            return StatusCode(200,
                                new 
                                {
                                    status = "Список языков пользователя успешно сформирован",
                                    languages
                                });
                        case false:
                            return StatusCode(404,
                                new 
                                {
                                    status = "У пользователя отсутствуют выбранные языки"
                                });
                    }
            }
        }

        #endregion



        #region POST

        [HttpPost("Languages")]
        public IActionResult AddLanguage(int userID, int languageID)
        {
            UserBaseInfoModel? user = _profile.GetProfileBaseInfo(userID);
            LanguageModel language = _profile.GetLanguageInfo(languageID);

            if (user is null)
            {
                return StatusCode(404,
                    new
                    {
                        status = "Пользователь с заданным идентификатором не найден"
                    });
            }
            if (language is null)
            {
                return StatusCode(404,
                    new
                    {
                        status = "Язык с заданным идентификатором не найден"
                    });
            }

            if (_profile.IsLanguageAdded(userID, languageID))
            {
                return StatusCode(406,
                    new
                    {
                        status = "Язык уже добавлен в список языков пользователя"
                    });
            }

            _profile.AddLanguage(userID, languageID);
            return StatusCode(200,
                new
                {
                    status = "Новый язык был успешно добавлен в профиль пользователя"
                });
        }

        #endregion



    }
}