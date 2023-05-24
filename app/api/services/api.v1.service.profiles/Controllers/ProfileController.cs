using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using db.v1.context.profiles.Wrappers;
using misc.jwt;
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
        private readonly IProfileWrapper _db;

        private int GetAuthUserID => AuthToken.GetUserID(HttpContext.Request.Headers);

        public ProfileController(IProfileWrapper db) => _db = db;


        #region GET

        /// <summary>
        /// Получить базовую информацию о профиле авторизованного пользователя
        /// </summary>
        [HttpGet("Base")]
        public IActionResult GetBaseProfileInfo() => StatusCode(200, new
        {
            status = "Базовая информация о профиле пользователе была успешно сформирована",
            data = _db.Profiles.GetProfileBaseInfo(GetAuthUserID)
        });

        /// <summary>
        /// Получить список языков авторизованного пользователя
        /// </summary>
        [HttpGet("Languages")]
        public IActionResult GetLanguagesInfo()
        {
            var languages = _db.Profiles.GetLanguages(GetAuthUserID);
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
            var positions = _db.Profiles.GetLifePositions(GetAuthUserID);
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
            var carrers = _db.Profiles.GetCarrers(GetAuthUserID);
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
            var services = _db.Profiles.GetMilitaryServices(GetAuthUserID);
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
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("Base/{userID:int}")]
        public IActionResult GetBaseProfileInfo(int userID) => _db.Profiles.IsProfileExist(userID) ?
            StatusCode(200, new 
            { 
                status = "Базовая информация о профиле пользователе была успешно сформирована", 
                data = _db.Profiles.GetProfileBaseInfo(userID) 
            }) :
            StatusCode(404, new 
            { 
                status = "Пользователя с заданным идентификатором не существует" 
            });

        /// <summary>
        /// Получить список языков пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("Languages/{userID:int}")]
        public IActionResult GetLanguagesInfo(int userID)
        {
            if (!_db.Profiles.IsProfileExist(userID))
            {
                return StatusCode(404, new 
                { 
                    status = "Пользователя с заданным идентификатором не существует" 
                });
            }

            var languages = _db.Profiles.GetLanguages(userID);
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
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("LifePositions/{userID:int}")]
        public IActionResult GetLifePositionsInfo(int userID) 
        {
            if (!_db.Profiles.IsProfileExist(userID))
            {
                return StatusCode(404, new
                {
                    status = "Пользователя с заданным идентификатором не существует"
                });
            }

            var positions = _db.Profiles.GetLifePositions(userID);
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
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("Carrers/{userID:int}")]
        public IActionResult GetCarrersInfo(int userID)
        {
            if (!_db.Profiles.IsProfileExist(userID))
            {
                return StatusCode(404, new
                {
                    status = "Пользователя с заданным идентификатором не существует"
                });
            }

            var carrers = _db.Profiles.GetCarrers(userID);
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
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("Militaries/{userID:int}")]
        public IActionResult GetMilitaryServicesInfo(int userID)
        {
            if (!_db.Profiles.IsProfileExist(userID))
            {
                return StatusCode(404, new
                {
                    status = "Пользователя с заданным идентификатором не существует"
                });
            }

            var services = _db.Profiles.GetMilitaryServices(userID);
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
        /// <param name="langID">Идентификатор языка</param>
        [HttpPost("Languages")]
        public IActionResult AddLanguage([FromBody] int langID)
        {
            int userID = GetAuthUserID;

            if (!_db.Langs.IsLanguageExist(langID))
            {
                return StatusCode(404, new 
                { 
                    status = "Языка с заданным идентификатором не существует" 
                });
            }
            if (_db.Profiles.IsLanguageAdded(userID, langID))
            {
                return StatusCode(406, new 
                { 
                    status = "Язык уже добавлен в список языков пользователя" 
                });
            }

            _db.Profiles.AddLanguage(userID, langID);
            return StatusCode(200, new 
            { 
                status = "Новый язык был успешно добавлен" 
            });
        }

        /// <summary>
        /// Добавить жизненную позицию (ЖП) в список ЖП авторизованного пользователя
        /// </summary>
        /// <param name="typeID">Идентификатор типа ЖП</param>
        /// <param name="posID">Идентификатор ЖП</param>
        [HttpPost("LifePositions")]
        public IActionResult AddLifePosition([FromBody] int typeID, [FromBody] int posID)
        {
            int userID = GetAuthUserID;

            if (!_db.Positions.IsLifePositionExist(typeID, posID))
            {
                return StatusCode(404, new 
                { 
                    status = "Жизненной позиции с заданным идентификатором не существует" 
                });
            }
            if (_db.Profiles.IsPositionTypeAdded(userID, typeID))
            {
                _db.Profiles.RemoveLifePositionType(userID, typeID);
            }

            _db.Profiles.AddLifePosition(userID, posID);
            return StatusCode(200, new 
            { 
                status = "Новая жизненная позиция была успешно добавлена" 
            });
        }

        /// <summary>
        /// Добавить карьеру в список карьер авторизованного пользователя
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="dateFrom">Дата начала работы</param>
        /// <param name="dateTo">Дата окончания</param>
        [HttpPost("Carrers")]
        public IActionResult AddCarrer([FromBody] int cityID, [FromBody] string company, [FromBody] string? job, [FromBody] DateTime? dateFrom, [FromBody] DateTime? dateTo)
        {
            int userID = GetAuthUserID;

            if (!_db.Places.IsCityExist(cityID))
            {
                return StatusCode(404, new 
                { 
                    status = "Города с заданным идентификатором не существует" 
                });
            }
            if (_db.Profiles.IsCarrerAdded(userID, cityID, company, job, dateFrom, dateTo))
            {
                return StatusCode(406, new 
                { 
                    status = "Такая карьера уже была добавлена" 
                });
            }

            _db.Profiles.AddCarrer(userID, cityID, company, job, dateFrom, dateTo);
            return StatusCode(200, new 
            { 
                status = "Новая карьера была успешно добавлена" 
            });
        }

        /// <summary>
        /// Добавить ВС в список ВС авторизованного пользователя
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        /// <param name="unit">Место проведения ВС</param>
        /// <param name="dateFrom">Дата начала ВС</param>
        /// <param name="dateTo">Дата окончания ВС</param>
        [HttpPost("Militaries")]
        public IActionResult AddMilitaryService([FromBody] int countryID, [FromBody] string unit, [FromBody] DateTime? dateFrom, [FromBody] DateTime? dateTo)
        {
            int userID = GetAuthUserID;

            if (!_db.Places.IsCountryExist(countryID))
            {
                return StatusCode(404, new 
                { 
                    status = "Страны с заданным идентификатором не существует" 
                });
            }
            if (_db.Profiles.IsMilitaryServiceAdded(userID, countryID, unit, dateFrom, dateTo))
            {
                return StatusCode(406, new 
                { 
                    status = "Такая ВС уже добавлена в профиль пользователя" 
                });
            }

            _db.Profiles.AddMilitaryService(userID, countryID, unit, dateFrom, dateTo);
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
        public IActionResult UpdateProfileStatus([FromBody] string status)
        {
            _db.Profiles.ChangeStatus(GetAuthUserID, status);
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
            _db.Profiles.ChangeAvatar(GetAuthUserID, avatar);
            return StatusCode(200, new 
            { 
                status = "Аватарка пользователя в профиле была успешно обновлена" 
            });
        }

        /// <summary>
        /// Обновить город в профиле авторизованного пользователя
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        [HttpPut("Base/City")]
        public IActionResult UpdateProfileCity(int cityID) 
        {
            if (!_db.Places.IsCityExist(cityID))
            {
                return StatusCode(404, new 
                { 
                    status = "Города с заданным идентификатором не существует" 
                });
            }

            _db.Profiles.ChangeCity(GetAuthUserID, cityID);
            return StatusCode(200, new 
            { 
                status = "Город пользователя в профиле был успешно обновлён" 
            });
        }

        /// <summary>
        /// Обновить информацию о семейном положении в профиле пользователя
        /// </summary>
        /// <param name="statusID">Идентификатор статуса</param>
        [HttpPut("BaseInfo/FamilyStatus/Update/statusID={statusID:int}")]
        public IActionResult UpdateProfileFamilyStatus(int statusID) 
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_status.IsStatusExist(statusID)) 
                return StatusCode(404, new { status = "Семейного положения с заданным идентификатором не существует" });

            _db.ChangeFamilyStatus(userID, statusID);
            return StatusCode(200, new { status = "Статус пользователя в профиле был успешно обновлён" });
        }

        /// <summary>
        /// Обновить дату рождения в профиел пользователя
        /// </summary>
        /// <param name="date">Дата рождения</param>
        [HttpPut("BaseInfo/Birthdate/Update/date={date:datetime}")]
        public IActionResult UpdateProfileBirthdate(DateTime date)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            _db.ChangeBirthDate(userID, date);
            return StatusCode(200, new { status = "Дата рождения пользователя в профиле была успешно обновлена" });
        }

        /// <summary>
        /// Обновить ФИО в профиле пользователя
        /// </summary>
        /// <param name="surname">Фамилия пользователя</param>
        /// <param name="name">Имя пользователя</param>
        /// <param name="patronymic">Отчество пользователя</param>
        [HttpPut("BaseInfo/Fullname/Update/surname={surname}&name={name}&patronymic={patronymic}")]
        public IActionResult UpdateProfileFullname(string surname, string name, string? patronymic)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            _db.ChangeFullname(userID, surname, name, patronymic);
            return StatusCode(200, new { status = "ФИО пользователя в профиле было успешно обновлено" });
        }

        /// <summary>
        /// Обновить карьеру в профиле пользователя
        /// </summary>
        /// <param name="carrerID">Идентификатор карьеры</param>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="dateFrom">Дата начала карьеры</param>
        /// <param name="dateTo">Дата окончания</param>
        [HttpPut("Carrer/carrerID={carrerID:int}/Update/cityID={cityID:int}&company={company}&job={job}&dateFrom={dateFrom:datetime}&dateTo={dateTo:datetime}")]
        public IActionResult UpdateProfileCarrer(int carrerID, int cityID, string company, string? job, DateTime? dateFrom, DateTime? dateTo)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_place.IsCityExist(cityID))
                return StatusCode(404, new { status = "Города с заданным идентификатором не существует" });
            if (!_db.IsCarrerAdded(userID, carrerID))
                return StatusCode(404, new { status = "Карьеры с заданными параметрами не существует" });

            _db.UpdateCarrer(carrerID, cityID, company, job, dateFrom, dateTo);
            return StatusCode(200, new { status = "Обновление информации о карьере прошло успешно" });
        }

        /// <summary>
        /// Обновить ВС в профиле пользователя
        /// </summary>
        /// <param name="serviceID">Идентификатор ВС</param>
        /// <param name="countryID">Идентификатор страны</param>
        /// <param name="unit">Место проведения ВС</param>
        /// <param name="dateFrom">Дата начала ВС</param>
        /// <param name="dateTo">Дата окончания ВС</param>
        [HttpPut("Military/serviceID={serviceID:int}/Update/countryID={countryID:int}&unit={unit}&dateFrom={dateFrom:datetime}&dateTo={dateTo:datetime}")]
        public IActionResult UpdateProfileMilitaryService(int serviceID, int countryID, string unit, DateTime? dateFrom, DateTime? dateTo)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_place.IsCountryExist(countryID))
                return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });
            if (!_db.IsMilitaryServiceAdded(userID, countryID))
                return StatusCode(404, new { status = "ВС с заданными параметрами не существует" });

            _db.UpdateMilitaryService(serviceID, countryID, unit, dateFrom, dateTo);
            return StatusCode(200, new { status = "Обновление информации о ВС прошло успешно" });
        }

        #endregion



        #region DELETE

        /// <summary>
        /// Удалить из профиля пользователя некоторый язык
        /// </summary>
        /// <param name="langID">Идентификатор языка</param>
        [HttpDelete("Language/Delete/id={langID:int}")]
        public IActionResult RemoveLanguage(int langID)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_language.IsLanguageExist(langID)) 
                return StatusCode(404, new { status = "Языка с заданным идентификатором не существует" });
            if (!_db.IsLanguageAdded(userID, langID)) 
                return StatusCode(406, new { status = "У пользователя отсутствует заданный язык в списке языков" });

            _db.RemoveLanguage(userID, langID);
            return StatusCode(200, new { status = "Удаление языка из профиля пользователя прошло успешно" });
        }

        /// <summary>
        /// Удалить из профиля пользователя некоторую жизненную позицию
        /// </summary>
        /// <param name="typeID">Идентификатор категории жизненной позиции</param>
        /// <param name="posID">Идентификатор жизненной позиции</param>
        [HttpDelete("LifePosition/Delete/typeID={typeID:int}&posID={posID:int}")]
        public IActionResult RemoveLifePosition(int typeID, int posID)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_position.IsLifePositionExist(typeID, posID)) 
                return StatusCode(404, new { status = "Жизненной позиции в заданном типе не существует" });
            if (!_db.IsPositionAdded(userID, posID)) 
                return StatusCode(404, new { status = "Жизненной позиции с заданным идентификатором не существует" });

            _db.RemoveLifePosition(userID, posID);
            return StatusCode(200, new { status = "Удаление жизненной позиции прошло успешно" });
        }

        /// <summary>
        /// Удалить из профиля пользователя некоторую карьеру
        /// </summary>
        /// <param name="carrerID">Идентификатор карьеры</param>
        [HttpDelete("id={userID:int}/Carrer/Delete/carrerID={carrerID:int}")]
        public IActionResult RemoveCarrer(int carrerID)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_db.IsCarrerAdded(userID, carrerID))
                return StatusCode(404, new { status = "Карьеры с заданными параметрами не существует" });

            _db.RemoveCarrer(userID, carrerID);
            return StatusCode(200, new { status = "Удаление карьеры прошло успешно" });
        }

        /// <summary>
        /// Удалить из профиля пользователя некоторую ВС
        /// </summary>
        /// <param name="serviceID">Идентификатор ВС</param>
        [HttpDelete("Military/Delete/serviceID={serviceID:int}")]
        public IActionResult RemoveMilitaryService(int serviceID)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_db.IsMilitaryServiceAdded(userID, serviceID))
                return StatusCode(404, new { status = "ВС с заданными параметрами не существует" });

            _db.RemoveMilitaryService(userID, serviceID);
            return StatusCode(200, new { status = "Удаление ВС прошло успешно" });
        }

        #endregion



    }
}