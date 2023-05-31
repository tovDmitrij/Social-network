using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using db.v1.context.profiles.Wrappers;
using helpers.jwt;
namespace api.service.profile.Controllers
{
    /// <summary>
    /// Взаимодействие с профилем пользователя
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public sealed class ProfileController : ControllerBase
    {
        /// <summary>
        /// Взаимодействие с БД профилей пользователей
        /// </summary>
        private readonly IProfileWrapper _profWrapper;

        /// <summary>
        /// Взаимодействие с JWT-токеном
        /// </summary>
        private readonly IProfileServiceToken _jwt;

        /// <summary>
        /// Получить идентификатор авторизованного пользователя
        /// </summary>
        private int GetAuthUserID => _jwt.GetUserID(HttpContext.Request.Headers);

        public ProfileController(IProfileWrapper db, IProfileServiceToken jwt) 
        { 
            _profWrapper = db; 
            _jwt = jwt;
        }


        #region GET

        /// <summary>
        /// Получить базовую информацию о профиле авторизованного пользователя
        /// </summary>
        [HttpGet("Base")]
        public IActionResult GetBaseProfileInfo() => StatusCode(200, new
        {
            status = "Базовая информация о профиле пользователе была успешно сформирована",
            data = _profWrapper.Profiles.GetProfileBaseInfo(GetAuthUserID)
        });

        /// <summary>
        /// Получить список языков авторизованного пользователя
        /// </summary>
        [HttpGet("Languages")]
        public IActionResult GetLanguagesInfo()
        {
            var languages = _profWrapper.Profiles.GetLanguages(GetAuthUserID);
            return languages.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список языков пользователя был успешно сформирован", 
                    data = languages 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список языков пуст" 
                });
        }

        /// <summary>
        /// Получить список жизненных позиций авторизованного пользователя
        /// </summary>
        [HttpGet("LifePositions")]
        public IActionResult GetLifePositionsInfo()
        {
            var positions = _profWrapper.Profiles.GetLifePositions(GetAuthUserID);
            return positions.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список жизненных позиций был успешно сформирован", 
                    data = positions 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список жизненных позиций пуст" 
                });
        }

        /// <summary>
        /// Получить список карьер авторизованного пользователя
        /// </summary>
        [HttpGet("Carrers")]
        public IActionResult GetCarrersInfo()
        {
            var carrers = _profWrapper.Profiles.GetCarrers(GetAuthUserID);
            return carrers.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список карьер был успешно сформирован", 
                    data = carrers 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список карьер пуст" 
                });
        }

        /// <summary>
        /// Получить список ВС авторизованного пользователя
        /// </summary>
        [HttpGet("Militaries")]
        public IActionResult GetMilitaryServicesInfo()
        {
            var services = _profWrapper.Profiles.GetMilitaryServices(GetAuthUserID);
            return services.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список ВС был успешно сформирован", 
                    data = services 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список ВС пуст" 
                });
        }


        /// <summary>
        /// Получить базовую информацию о профиле пользователя по его идентификатору
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        [HttpGet("{user_id:int}/Base")]
        public IActionResult GetBaseProfileInfo(int user_id) => _profWrapper.Profiles.IsProfileExist(user_id) ?
            StatusCode(200, new 
            { 
                status = "Базовая информация о профиле пользователе была успешно сформирована", 
                data = _profWrapper.Profiles.GetProfileBaseInfo(user_id) 
            }) :
            StatusCode(404, new 
            { 
                status = "Пользователя с заданным идентификатором не существует" 
            });

        /// <summary>
        /// Получить список языков пользователя по его идентификатору
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        [HttpGet("{user_id:int}/Languages")]
        public IActionResult GetLanguagesInfo(int user_id)
        {
            if (!_profWrapper.Profiles.IsProfileExist(user_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Пользователя с заданным идентификатором не существует" 
                });
            }

            var languages = _profWrapper.Profiles.GetLanguages(user_id);
            return languages.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список языков пользователя был успешно сформирован", 
                    data = languages 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список языков пуст" 
                });
        }

        /// <summary>
        /// Получить список жизненных позиций пользователя по его идентификатору
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        [HttpGet("{user_id:int}/LifePositions")]
        public IActionResult GetLifePositionsInfo(int user_id) 
        {
            if (!_profWrapper.Profiles.IsProfileExist(user_id))
            {
                return StatusCode(404, new
                {
                    status = "Пользователя с заданным идентификатором не существует"
                });
            }

            var positions = _profWrapper.Profiles.GetLifePositions(user_id);
            return positions.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список жизненных позиций был успешно сформирован", 
                    data = positions 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список жизненных позиций пуст" 
                });
        }

        /// <summary>
        /// Получить список карьер пользователя по его идентификатору
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        [HttpGet("{user_id:int}/Carrers")]
        public IActionResult GetCarrersInfo(int user_id)
        {
            if (!_profWrapper.Profiles.IsProfileExist(user_id))
            {
                return StatusCode(404, new
                {
                    status = "Пользователя с заданным идентификатором не существует"
                });
            }

            var carrers = _profWrapper.Profiles.GetCarrers(user_id);
            return carrers.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список карьер был успешно сформирован", 
                    data = carrers 
                }) :
                StatusCode(404, new 
                { 
                    status = "Список карьер пуст" 
                });
        }

        /// <summary>
        /// Получить список ВС пользователя по его идентификатору
        /// </summary>
        /// <param name="user_id">Идентификатор пользователя</param>
        [HttpGet("{user_id:int}/Militaries")]
        public IActionResult GetMilitaryServicesInfo(int user_id)
        {
            if (!_profWrapper.Profiles.IsProfileExist(user_id))
            {
                return StatusCode(404, new
                {
                    status = "Пользователя с заданным идентификатором не существует"
                });
            }

            var services = _profWrapper.Profiles.GetMilitaryServices(user_id);
            return services.Any() ?
                StatusCode(200, new 
                { 
                    status = "Список ВС был успешно сформирован", 
                    data = services 
                }) :
                StatusCode(404, new
                { 
                    status = "Список ВС пуст" 
                });
        }

        #endregion



        #region POST

        /// <summary>
        /// Добавить язык в список языков авторизованного пользователя
        /// </summary>
        /// <param name="lang_id">Идентификатор языка</param>
        [HttpPost("Languages")]
        public IActionResult AddLanguage(int lang_id)
        {
            int user_id = GetAuthUserID;

            if (!_profWrapper.Langs.IsLanguageExist(lang_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Языка с заданным идентификатором не существует" 
                });
            }
            if (_profWrapper.Profiles.IsLanguageAdded(user_id, lang_id))
            {
                return StatusCode(406, new 
                { 
                    status = "Язык уже добавлен в список языков пользователя" 
                });
            }

            _profWrapper.Profiles.AddLanguage(user_id, lang_id);
            return StatusCode(200, new 
            { 
                status = "Новый язык был успешно добавлен" 
            });
        }

        /// <summary>
        /// Добавить жизненную позицию (ЖП) в список ЖП авторизованного пользователя
        /// </summary>
        /// <param name="type_id">Идентификатор типа ЖП</param>
        /// <param name="pos_id">Идентификатор ЖП</param>
        [HttpPost("LifePositions")]
        public IActionResult AddLifePosition(int type_id, int pos_id)
        {
            int user_id = GetAuthUserID;

            if (!_profWrapper.Positions.IsLifePositionExist(type_id, pos_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Жизненной позиции с заданным идентификатором не существует" 
                });
            }
            if (_profWrapper.Profiles.IsPositionTypeAdded(user_id, type_id))
            {
                _profWrapper.Profiles.RemoveLifePositionType(user_id, type_id);
            }

            _profWrapper.Profiles.AddLifePosition(user_id, pos_id);
            return StatusCode(200, new 
            { 
                status = "Новая жизненная позиция была успешно добавлена" 
            });
        }

        /// <summary>
        /// Добавить карьеру в список карьер авторизованного пользователя
        /// </summary>
        /// <param name="city_id">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="date_from">Дата начала работы</param>
        /// <param name="date_to">Дата окончания</param>
        [HttpPost("Carrers")]
        public IActionResult AddCarrer(int city_id, string company, string? job, DateTime? date_from, DateTime? date_to)
        {
            int user_id = GetAuthUserID;

            if (!_profWrapper.Places.IsCityExist(city_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Города с заданным идентификатором не существует" 
                });
            }
            if (_profWrapper.Profiles.IsCarrerAdded(user_id, city_id, company, job, date_from, date_to))
            {
                return StatusCode(406, new 
                { 
                    status = "Такая карьера уже была добавлена" 
                });
            }

            _profWrapper.Profiles.AddCarrer(user_id, city_id, company, job, date_from, date_to);
            return StatusCode(200, new 
            { 
                status = "Новая карьера была успешно добавлена" 
            });
        }

        /// <summary>
        /// Добавить ВС в список ВС авторизованного пользователя
        /// </summary>
        /// <param name="country_id">Идентификатор страны</param>
        /// <param name="unit">Место проведения ВС</param>
        /// <param name="date_from">Дата начала ВС</param>
        /// <param name="date_to">Дата окончания ВС</param>
        [HttpPost("Militaries")]
        public IActionResult AddMilitaryService(int country_id, string unit, DateTime? date_from, DateTime? date_to)
        {
            int user_id = GetAuthUserID;

            if (!_profWrapper.Places.IsCountryExist(country_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Страны с заданным идентификатором не существует" 
                });
            }
            if (_profWrapper.Profiles.IsMilitaryServiceAdded(user_id, country_id, unit, date_from, date_to))
            {
                return StatusCode(406, new 
                { 
                    status = "Такая ВС уже добавлена в профиль пользователя" 
                });
            }

            _profWrapper.Profiles.AddMilitaryService(user_id, country_id, unit, date_from, date_to);
            return StatusCode(200, new 
            { 
                status = "Новая ВС была успешно добавлена" 
            });
        }

        #endregion



        #region PUT

        /// <summary>
        /// Обновить статус в профиле авторизованного пользователя
        /// </summary>
        /// <param name="status">Статус пользователя</param>
        [HttpPut("Base/Status")]
        public IActionResult UpdateProfileStatus(string status)
        {
            _profWrapper.Profiles.ChangeStatus(GetAuthUserID, status);
            return StatusCode(200, new 
            { 
                status = "Статус пользователя в профиле был успешно обновлён" 
            });
        }

        /// <summary>
        /// Обновить аватар в профиле авторизованного пользователя
        /// </summary>
        /// <param name="avatar">Аватарка</param>
        [HttpPut("Base/Avatar")]
        public IActionResult UpdateProfileAvatar(string avatar)
        {
            _profWrapper.Profiles.ChangeAvatar(GetAuthUserID, avatar);
            return StatusCode(200, new 
            { 
                status = "Аватарка пользователя в профиле была успешно обновлена" 
            });
        }

        /// <summary>
        /// Обновить город в профиле авторизованного пользователя
        /// </summary>
        /// <param name="city_id">Идентификатор города</param>
        [HttpPut("Base/City")]
        public IActionResult UpdateProfileCity(int city_id) 
        {
            if (!_profWrapper.Places.IsCityExist(city_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Города с заданным идентификатором не существует" 
                });
            }

            _profWrapper.Profiles.ChangeCity(GetAuthUserID, city_id);
            return StatusCode(200, new 
            { 
                status = "Город пользователя в профиле был успешно обновлён" 
            });
        }

        /// <summary>
        /// Обновить информацию о семейном положении в профиле авторизованного пользователя
        /// </summary>
        /// <param name="status_id">Идентификатор статуса</param>
        [HttpPut("Base/FamilyStatus")]
        public IActionResult UpdateProfileFamilyStatus(int status_id) 
        {
            if (!_profWrapper.Families.IsStatusExist(status_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Семейного положения с заданным идентификатором не существует" 
                });
            }

            _profWrapper.Profiles.ChangeFamilyStatus(GetAuthUserID, status_id);
            return StatusCode(200, new 
            { 
                status = "Статус пользователя в профиле был успешно обновлён" 
            });
        }

        /// <summary>
        /// Обновить дату рождения в профиле авторизованного пользователя
        /// </summary>
        /// <param name="date">Дата рождения</param>
        [HttpPut("Base/Birthdate")]
        public IActionResult UpdateProfileBirthdate(DateTime date)
        {
            _profWrapper.Profiles.ChangeBirthDate(GetAuthUserID, date);
            return StatusCode(200, new 
            { 
                status = "Дата рождения пользователя в профиле была успешно обновлена" 
            });
        }

        /// <summary>
        /// Обновить фамилию в профиле авторизованного пользователя
        /// </summary>
        /// <param name="surname">Фамилия пользователя</param>
        [HttpPut("Base/Surname")]
        public IActionResult UpdateProfileSurname(string surname)
        {
            _profWrapper.Profiles.ChangeSurname(GetAuthUserID, surname);
            return StatusCode(200, new 
            { 
                status = "Фамилия пользователя в профиле была успешно обновлена" 
            });
        }

        /// <summary>
        /// Обновить имя в профиле авторизованного пользователя
        /// </summary>
        /// <param name="name">Имя пользователя</param>
        [HttpPut("Base/Name")]
        public IActionResult UpdateProfileName(string name)
        {
            _profWrapper.Profiles.ChangeName(GetAuthUserID, name);
            return StatusCode(200, new
            {
                status = "Имя пользователя в профиле было успешно обновлено"
            });
        }

        /// <summary>
        /// Обновить отчество в профиле авторизованного пользователя
        /// </summary>
        /// <param name="patronymic">Отчество пользователя</param>
        [HttpPut("Base/Patronymic")]
        public IActionResult UpdateProfilePatronymic(string patronymic)
        {
            _profWrapper.Profiles.ChangePatronymic(GetAuthUserID, patronymic);
            return StatusCode(200, new
            {
                status = "Отчество пользователя в профиле было успешно обновлено"
            });
        }

        /// <summary>
        /// Обновить карьеру в профиле авторизованного пользователя
        /// </summary>
        /// <param name="carrer_id">Идентификатор карьеры</param>
        /// <param name="city_id">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="date_from">Дата начала карьеры</param>
        /// <param name="date_to">Дата окончания</param>
        [HttpPut("Carrers")]
        public IActionResult UpdateProfileCarrer(int carrer_id, int city_id, string company, string? job, DateTime? date_from, DateTime? date_to)
        {
            if (!_profWrapper.Places.IsCityExist(city_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Города с заданным идентификатором не существует" 
                });
            }
            if (!_profWrapper.Profiles.IsCarrerAdded(GetAuthUserID, carrer_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Карьеры с заданными параметрами не существует" 
                });
            }

            _profWrapper.Profiles.UpdateCarrer(carrer_id, city_id, company, job, date_from, date_to);
            return StatusCode(200, new 
            { 
                status = "Обновление информации о карьере прошло успешно" 
            });
        }

        /// <summary>
        /// Обновить ВС в профиле авторизованного пользователя
        /// </summary>
        /// <param name="service_id">Идентификатор ВС</param>
        /// <param name="country_id">Идентификатор страны</param>
        /// <param name="military_unit">Место проведения ВС</param>
        /// <param name="date_from">Дата начала ВС</param>
        /// <param name="date_to">Дата окончания ВС</param>
        [HttpPut("Militaries")]
        public IActionResult UpdateProfileMilitaryService(int service_id, int country_id, string military_unit, DateTime? date_from, DateTime? date_to)
        {
            if (!_profWrapper.Places.IsCountryExist(country_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Страны с заданным идентификатором не существует" 
                });
            }
            if (!_profWrapper.Profiles.IsMilitaryServiceAdded(GetAuthUserID, service_id))
            {
                return StatusCode(404, new
                {
                    status = "ВС с заданными параметрами не существует"
                });
            }

            _profWrapper.Profiles.UpdateMilitaryService(service_id, country_id, military_unit, date_from, date_to);
            return StatusCode(200, new 
            { 
                status = "Обновление информации о ВС прошло успешно" 
            });
        }

        #endregion



        #region DELETE

        /// <summary>
        /// Удалить из профиля авторизованного пользователя язык
        /// </summary>
        /// <param name="lang_id">Идентификатор языка</param>
        [HttpDelete("Languages")]
        public IActionResult RemoveLanguage(int lang_id)
        {
            int user_id = GetAuthUserID;

            if (!_profWrapper.Langs.IsLanguageExist(lang_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Языка с заданным идентификатором не существует" 
                });
            }
            if (!_profWrapper.Profiles.IsLanguageAdded(user_id, lang_id))
            {
                return StatusCode(406, new 
                { 
                    status = "У пользователя отсутствует заданный язык в списке языков" 
                });
            }

            _profWrapper.Profiles.RemoveLanguage(user_id, lang_id);
            return StatusCode(200, new 
            { 
                status = "Удаление языка из профиля пользователя прошло успешно" 
            });
        }

        /// <summary>
        /// Удалить из профиля авторизованного пользователя жизненную позицию
        /// </summary>
        /// <param name="type_id">Идентификатор категории жизненной позиции</param>
        /// <param name="pos_id">Идентификатор жизненной позиции</param>
        [HttpDelete("LifePositions")]
        public IActionResult RemoveLifePosition(int type_id, int pos_id)
        {
            int user_id = GetAuthUserID;

            if (!_profWrapper.Positions.IsLifePositionExist(type_id, pos_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Жизненной позиции в заданном типе не существует" 
                });
            }
            if (!_profWrapper.Profiles.IsPositionAdded(user_id, pos_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Жизненной позиции с заданным идентификатором не существует" 
                });
            }

            _profWrapper.Profiles.RemoveLifePosition(user_id, pos_id);
            return StatusCode(200, new 
            { 
                status = "Удаление жизненной позиции прошло успешно" 
            });
        }

        /// <summary>
        /// Удалить из профиля авторизованного пользователя карьеру
        /// </summary>
        /// <param name="carrer_id">Идентификатор карьеры</param>
        [HttpDelete("Carrers")]
        public IActionResult RemoveCarrer(int carrer_id)
        {
            int user_id = GetAuthUserID;

            if (!_profWrapper.Profiles.IsCarrerAdded(user_id, carrer_id))
            {
                return StatusCode(404, new 
                { 
                    status = "Карьеры с заданными параметрами не существует" 
                });
            }

            _profWrapper.Profiles.RemoveCarrer(user_id, carrer_id);
            return StatusCode(200, new 
            { 
                status = "Удаление карьеры прошло успешно" 
            });
        }

        /// <summary>
        /// Удалить из профиля авторизованного пользователя ВС
        /// </summary>
        /// <param name="service_id">Идентификатор ВС</param>
        [HttpDelete("Militaries")]
        public IActionResult RemoveMilitaryService(int service_id)
        {
            int user_id = GetAuthUserID;

            if (!_profWrapper.Profiles.IsMilitaryServiceAdded(user_id, service_id))
            {
                return StatusCode(404, new 
                { 
                    status = "ВС с заданными параметрами не существует" 
                });
            }

            _profWrapper.Profiles.RemoveMilitaryService(user_id, service_id);
            return StatusCode(200, new 
            { 
                status = "Удаление ВС прошло успешно" 
            });
        }

        #endregion



    }
}