using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using database.context.main.Repos.Profile;
using database.context.main.Repos.Languages;
using database.context.main.Repos.LifePositions;
using database.context.main.Repos.Cities;
using database.context.main.Repos.FamilyStatuses;
using api.service.profile.Misc;
namespace api.service.profile.Controllers
{
    /// <summary>
    /// Взаимодействие с профилем пользователей
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public sealed class ProfileController : ControllerBase
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
        /// Получить базовую информацию о профиле пользователя
        /// </summary>
        [HttpGet("BaseInfo/Get")]
        public IActionResult GetBaseProfileInfo() => StatusCode(200, new
        {
            status = "Базовая информация о профиле пользователе была успешно сформирована",
            data = _profile.GetProfileBaseInfo(AuthOptions.GetUserID(HttpContext))
        });

        /// <summary>
        /// Получить список языков пользователя
        /// </summary>
        [HttpGet("Languages/Get")]
        public IActionResult GetLanguagesInfo()
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            var languages = _profile.GetLanguages(userID);
            return languages.Any() ?
                StatusCode(200, new { status = "Список языков пользователя был успешно сформирован", data = languages }) :
                StatusCode(404, new { status = "Список языков пуст" });
        }

        /// <summary>
        /// Получить список жизненных позиций пользователя
        /// </summary>
        [HttpGet("LifePositions/Get")]
        public IActionResult GetLifePositionsInfo()
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            var positions = _profile.GetLifePositions(userID);
            return positions.Any() ?
                StatusCode(200, new { status = "Список жизненных позиций был успешно сформирован", data = positions }) :
                StatusCode(404, new { status = "Список жизненных позиций пуст" });
        }

        /// <summary>
        /// Получить список карьер пользователя
        /// </summary>
        [HttpGet("Carrers/Get")]
        public IActionResult GetCarrersInfo()
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            var carrers = _profile.GetCarrers(userID);
            return carrers.Any() ?
                StatusCode(200, new { status = "Список карьер был успешно сформирован", data = carrers }) :
                StatusCode(404, new { status = "Список карьер пуст" });
        }

        /// <summary>
        /// Получить список ВС пользователя
        /// </summary>
        [HttpGet("Militaries/Get")]
        public IActionResult GetMilitaryServicesInfo()
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            var services = _profile.GetMilitaryServices(userID);
            return services.Any() ?
                StatusCode(200, new { status = "Список ВС был успешно сформирован", data = services }) :
                StatusCode(404, new { status = "Список ВС пуст" });
        }


        /// <summary>
        /// Получить базовую информацию о профиле пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("id={userID:int}/BaseInfo/Get")]
        public IActionResult GetBaseProfileInfo(int userID) => _profile.IsUserExist(userID) ?
            StatusCode(200, new { status = "Базовая информация о профиле пользователе была успешно сформирована", data = _profile.GetProfileBaseInfo(userID) }) :
            StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });

        /// <summary>
        /// Получить список языков пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("id={userID:int}/Languages/Get")]
        public IActionResult GetLanguagesInfo(int userID)
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });

            var languages = _profile.GetLanguages(userID);
            return languages.Any() ?
                StatusCode(200, new { status = "Список языков пользователя был успешно сформирован", data = languages }) :
                StatusCode(404, new { status = "Список языков пуст" });
        }

        /// <summary>
        /// Получить список жизненных позиций пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("id={userID:int}/LifePositions/Get")]
        public IActionResult GetLifePositionsInfo(int userID) 
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            
            var positions = _profile.GetLifePositions(userID);
            return positions.Any() ?
                StatusCode(200, new { status = "Список жизненных позиций был успешно сформирован", data = positions }) :
                StatusCode(404, new { status = "Список жизненных позиций пуст" });
        }

        /// <summary>
        /// Получить список карьер пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("id={userID:int}/Carrers/Get")]
        public IActionResult GetCarrersInfo(int userID)
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });

            var carrers = _profile.GetCarrers(userID);
            return carrers.Any() ?
                StatusCode(200, new { status = "Список карьер был успешно сформирован", data = carrers }) :
                StatusCode(404, new { status = "Список карьер пуст" });
        }

        /// <summary>
        /// Получить список ВС пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("id={userID:int}/Militaries/Get")]
        public IActionResult GetMilitaryServicesInfo(int userID)
        {
            if (!_profile.IsUserExist(userID))
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });

            var services = _profile.GetMilitaryServices(userID);
            return services.Any() ?
                StatusCode(200, new { status = "Список ВС был успешно сформирован", data = services }) :
                StatusCode(404, new { status = "Список ВС пуст" });
        }

        #endregion



        #region POST

        /// <summary>
        /// Добавить язык в список языков пользователя
        /// </summary>
        /// <param name="langID">Идентификатор языка</param>
        [HttpPost("Language/Add/id={langID:int}")]
        public IActionResult AddLanguage(int langID)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_language.IsLanguageExist(langID)) 
                return StatusCode(404, new { status = "Языка с заданным идентификатором не существует" }); ;
            if (_profile.IsLanguageAdded(userID, langID)) 
                return StatusCode(406, new { status = "Язык уже добавлен в список языков пользователя" });

            _profile.AddLanguage(userID, langID);
            return StatusCode(200, new { status = "Новый язык был успешно добавлен" });
        }

        /// <summary>
        /// Добавить жизненную позицию (ЖП) в список ЖП пользователя
        /// </summary>
        /// <param name="typeID">Идентификатор типа ЖП</param>
        /// <param name="posID">Идентификатор ЖП</param>
        [HttpPost("LifePosition/Add/typeID={typeID:int}&posID={posID:int}")]
        public IActionResult AddLifePosition(int typeID, int posID)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_position.IsLifePositionExist(typeID, posID)) 
                return StatusCode(404, new { status = "Жизненной позиции с заданным идентификатором не существует" });
            if (_profile.IsPositionTypeAdded(userID, typeID)) 
                _profile.RemoveLifePositionType(userID, typeID);

            _profile.AddLifePosition(userID, posID);
            return StatusCode(200, new { status = "Новая жизненная позиция была успешно добавлена" });
        }

        /// <summary>
        /// Добавить карьеру в список карьер пользователя
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="dateFrom">Дата начала работы</param>
        /// <param name="dateTo">Дата окончания</param>
        [HttpPost("Carrer/Add/cityID={cityID:int}&company={company}&job={job}&dateFrom={dateFrom:datetime}&dateTo={dateTo:datetime}")]
        public IActionResult AddCarrer(int cityID, string company, string? job, DateTime? dateFrom, DateTime? dateTo)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_place.IsCityExist(cityID))
                return StatusCode(404, new { status = "Города с заданным идентификатором не существует" });
            if (_profile.IsCarrerAdded(userID, cityID, company, job, dateFrom, dateTo))
                return StatusCode(406, new { status = "Такая карьера уже была добавлена" });

            _profile.AddCarrer(userID, cityID, company, job, dateFrom, dateTo);
            return StatusCode(200, new { status = "Новая карьера была успешно добавлена" });
        }

        /// <summary>
        /// Добавить ВС в список ВС пользователя
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        /// <param name="unit">Место проведения ВС</param>
        /// <param name="dateFrom">Дата начала ВС</param>
        /// <param name="dateTo">Дата окончания ВС</param>
        [HttpPost("Military/Add/countryID={countryID:int}&unit={unit}&dateFrom={dateFrom:datetime}&dateTo={dateTo:datetime}")]
        public IActionResult AddMilitaryService(int countryID, string unit, DateTime? dateFrom, DateTime? dateTo)
        {
            int userID = AuthOptions.GetUserID(HttpContext);

            if (!_place.IsCountryExist(countryID))
                return StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });
            if (_profile.IsMilitaryServiceAdded(userID, countryID, unit, dateFrom, dateTo))
                return StatusCode(406, new { status = "Такая ВС уже добавлена в профиль пользователя" });

            _profile.AddMilitaryService(userID, countryID, unit, dateFrom, dateTo);
            return StatusCode(200, new { status = "Новая ВС была успешно добавлена" });
        }

        #endregion



        #region PUT

        /// <summary>
        /// Обновить статус в профиле пользователя
        /// </summary>
        /// <param name="status">Статус пользователя</param>
        [HttpPut("BaseInfo/Status/Update/status={status}")]
        public IActionResult UpdateProfileStatus(string status)
        {
            int userID = AuthOptions.GetUserID(HttpContext);
            
            _profile.ChangeStatus(userID, status);
            return StatusCode(200, new { status = "Статус пользователя в профиле был успешно обновлён" });
        }

        /// <summary>
        /// Обновить аватар в профиле пользователя
        /// </summary>
        /// <param name="avatar">Аватарка</param>
        [HttpPut("BaseInfo/Avatar/Update/avatar={avatar}")]
        public IActionResult UpdateProfileAvatar(string avatar)
        {
            int userID = AuthOptions.GetUserID(HttpContext);
           
            _profile.ChangeAvatar(userID, avatar);
            return StatusCode(200, new { status = "Аватарка пользователя в профиле была успешно обновлена" });
        }

        /// <summary>
        /// Обновить город в профиле пользователя
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        [HttpPut("BaseInfo/City/Update/cityID={cityID:int}")]
        public IActionResult UpdateProfileCity(int cityID) 
        {
            int userID = AuthOptions.GetUserID(HttpContext);
            
            if (!_place.IsCityExist(cityID)) 
                return StatusCode(404, new { status = "Города с заданным идентификатором не существует" });

            _profile.ChangeCity(userID, cityID);
            return StatusCode(200, new { status = "Город пользователя в профиле был успешно обновлён" });
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

            _profile.ChangeFamilyStatus(userID, statusID);
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

            _profile.ChangeBirthDate(userID, date);
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

            _profile.ChangeFullname(userID, surname, name, patronymic);
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
            if (!_profile.IsCarrerAdded(userID, carrerID))
                return StatusCode(404, new { status = "Карьеры с заданными параметрами не существует" });

            _profile.UpdateCarrer(carrerID, cityID, company, job, dateFrom, dateTo);
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
            if (!_profile.IsMilitaryServiceAdded(userID, countryID))
                return StatusCode(404, new { status = "ВС с заданными параметрами не существует" });

            _profile.UpdateMilitaryService(serviceID, countryID, unit, dateFrom, dateTo);
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
            if (!_profile.IsLanguageAdded(userID, langID)) 
                return StatusCode(406, new { status = "У пользователя отсутствует заданный язык в списке языков" });

            _profile.RemoveLanguage(userID, langID);
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
            if (!_profile.IsPositionAdded(userID, posID)) 
                return StatusCode(404, new { status = "Жизненной позиции с заданным идентификатором не существует" });

            _profile.RemoveLifePosition(userID, posID);
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

            if (!_profile.IsCarrerAdded(userID, carrerID))
                return StatusCode(404, new { status = "Карьеры с заданными параметрами не существует" });

            _profile.RemoveCarrer(userID, carrerID);
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

            if (!_profile.IsMilitaryServiceAdded(userID, serviceID))
                return StatusCode(404, new { status = "ВС с заданными параметрами не существует" });

            _profile.RemoveMilitaryService(userID, serviceID);
            return StatusCode(200, new { status = "Удаление ВС прошло успешно" });
        }

        #endregion



    }
}