using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [ProducesResponseType(typeof(string), 401)]
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
        /// Получить базовую информацию о профиле пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("userID={userID:int}/BaseInfo/Get")]
        public IActionResult GetBaseProfileInfo(int userID) => _profile.IsUserExist(userID) ?
            StatusCode(200, new { status = "Базовая информация о профиле пользователе была успешно сформирована", data = _profile.GetProfileBaseInfo(userID) }) :
            StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });

        /// <summary>
        /// Получить список языков пользователя по его идентификатору
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        [HttpGet("userID={userID:int}/Languages/Get")]
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
        [HttpGet("userID={userID:int}/LifePositions/Get")]
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
        [HttpGet("userID={userID:int}/Carrers/Get")]
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
        [HttpGet("userID={userID:int}/Militaries/Get")]
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
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="langID">Идентификатор языка</param>
        [HttpPost("userID={userID:int}/Language/Add/langID={langID:int}")]
        public IActionResult AddLanguage(int userID, int langID)
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            if (!_language.IsLanguageExist(langID)) 
                return StatusCode(404, new { status = "Языка с заданным идентификатором не существует" }); ;
            if (_profile.IsLanguageAdded(userID, langID)) 
                return StatusCode(406, new { status = "Язык уже добавлен в список языков пользователя" });

            _profile.AddLanguage(userID, langID);
            return StatusCode(200, new { status = "Новая жизненная позиция была успешно добавлена" });
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
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
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
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="dateFrom">Дата начала работы</param>
        /// <param name="dateTo">Дата окончания</param>
        [HttpPost("userID={userID:int}/Carrer/Add/cityID={cityID:int}&company={company}&job={job}&dateFrom={dateFrom:datetime}&dateTo={dateTo:datetime}")]
        public IActionResult AddCarrer(int userID, int cityID, string company, string? job, DateTime? dateFrom, DateTime? dateTo)
        {
            if (!_profile.IsUserExist(userID))
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
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
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="countryID">Идентификатор страны</param>
        /// <param name="unit">Место проведения ВС</param>
        /// <param name="dateFrom">Дата начала ВС</param>
        /// <param name="dateTo">Дата окончания ВС</param>
        [HttpPost("userID={userID:int}/Military/Add/countryID={countryID:int}&unit={unit}&dateFrom={dateFrom:datetime}&dateTo={dateTo:datetime}")]
        public IActionResult AddMilitaryService(int userID, int countryID, string unit, DateTime? dateFrom, DateTime? dateTo)
        {
            if (!_profile.IsUserExist(userID))
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
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
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="status">Статус пользователя</param>
        [HttpPut("userID={userID:int}/BaseInfo/Status/Update/status={status}")]
        public IActionResult UpdateProfileStatus(int userID, string status)
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });

            _profile.ChangeStatus(userID, status);
            return StatusCode(200, new { status = "Статус пользователя в профиле был успешно обновлён" });
        }

        /// <summary>
        /// Обновить аватар в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентфикатор пользователя</param>
        /// <param name="avatar">Аватарка</param>
        [HttpPut("userID={userID:int}/BaseInfo/Avatar/Update/avatar={avatar}")]
        public IActionResult UpdateProfileAvatar(int userID, string avatar)
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });

            _profile.ChangeAvatar(userID, Encoding.UTF8.GetBytes(avatar));
            return StatusCode(200, new { status = "Аватарка пользователя в профиле была успешно обновлена" });
        }

        /// <summary>
        /// Обновить город в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="cityID">Идентификатор города</param>
        [HttpPut("userID={userID:int}/BaseInfo/City/Update/cityID={cityID:int}")]
        public IActionResult UpdateProfileCity(int userID, int cityID) 
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            if (!_place.IsCityExist(cityID)) 
                return StatusCode(404, new { status = "Города с заданным идентификатором не существует" });

            _profile.ChangeCity(userID, cityID);
            return StatusCode(200, new { status = "Город пользователя в профиле был успешно обновлён" });
        }

        /// <summary>
        /// Обновить информацию о семейном положении в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="statusID">Идентификатор статуса</param>
        [HttpPut("userID={userID:int}/BaseInfo/FamilyStatus/Update/statusID={statusID:int}")]
        public IActionResult UpdateProfileFamilyStatus(int userID, int statusID) 
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            if (!_status.IsStatusExist(statusID)) 
                return StatusCode(404, new { status = "Семейного положения с заданным идентификатором не существует" });

            _profile.ChangeFamilyStatus(userID, statusID);
            return StatusCode(200, new { status = "Статус пользователя в профиле был успешно обновлён" });
        }

        /// <summary>
        /// Обновить дату рождения в профиел пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="date">Дата рождения</param>
        [HttpPut("userID={userID:int}/BaseInfo/Birthdate/Update/date={date:datetime}")]
        public IActionResult UpdateProfileBirthdate(int userID, DateTime date)
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });

            _profile.ChangeBirthDate(userID, date);
            return StatusCode(200, new { status = "Дата рождения пользователя в профиле была успешно обновлена" });
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
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });

            _profile.ChangeFullname(userID, surname, name, patronymic);
            return StatusCode(200, new { status = "ФИО пользователя в профиле было успешно обновлено" });
        }

        /// <summary>
        /// Обновить карьеру в профиле пользователя
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="carrerID">Идентификатор карьеры</param>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="company">Наименование компании</param>
        /// <param name="job">Наименование должности</param>
        /// <param name="dateFrom">Дата начала карьеры</param>
        /// <param name="dateTo">Дата окончания</param>
        [HttpPut("userID={userID:int}/Carrer/carrerID={carrerID:int}/Update/cityID={cityID:int}&company={company}&job={job}&dateFrom={dateFrom:datetime}&dateTo={dateTo:datetime}")]
        public IActionResult UpdateProfileCarrer(int userID, int carrerID, int cityID, string company, string? job, DateTime? dateFrom, DateTime? dateTo)
        {
            if (!_profile.IsUserExist(userID))
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
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
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="serviceID">Идентификатор ВС</param>
        /// <param name="countryID">Идентификатор страны</param>
        /// <param name="unit">Место проведения ВС</param>
        /// <param name="dateFrom">Дата начала ВС</param>
        /// <param name="dateTo">Дата окончания ВС</param>
        [HttpPut("userID={userID:int}/Military/serviceID={serviceID:int}/Update/countryID={countryID:int}&unit={unit}&dateFrom={dateFrom:datetime}&dateTo={dateTo:datetime}")]
        public IActionResult UpdateProfileMilitaryService(int userID, int serviceID, int countryID, string unit, DateTime? dateFrom, DateTime? dateTo)
        {
            if (!_profile.IsUserExist(userID))
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
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
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="langID">Идентификатор языка</param>
        [HttpDelete("userID={userID:int}/Language/Delete/langID={langID:int}")]
        public IActionResult RemoveLanguage(int userID, int langID)
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
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
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="typeID">Идентификатор категории жизненной позиции</param>
        /// <param name="posID">Идентификатор жизненной позиции</param>
        [HttpDelete("userID={userID:int}/LifePosition/Delete/typeID={typeID:int}&posID={posID:int}")]
        public IActionResult RemoveLifePosition(int userID, int typeID, int posID)
        {
            if (!_profile.IsUserExist(userID)) 
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
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
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="carrerID">Идентификатор карьеры</param>
        [HttpDelete("userID={userID:int}/Carrer/Delete/carrerID={carrerID:int}")]
        public IActionResult RemoveCarrer(int userID, int  carrerID)
        {
            if (!_profile.IsUserExist(userID))
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            if (!_profile.IsCarrerAdded(userID, carrerID))
                return StatusCode(404, new { status = "Карьеры с заданными параметрами не существует" });

            _profile.RemoveCarrer(userID, carrerID);
            return StatusCode(200, new { status = "Удаление карьеры прошло успешно" });
        }

        /// <summary>
        /// Удалить из профиля пользователя некоторую ВС
        /// </summary>
        /// <param name="userID">Идентификатор пользователя</param>
        /// <param name="serviceID">Идентификатор ВС</param>
        [HttpDelete("userID={userID:int}/Military/Delete/serviceID={serviceID:int}")]
        public IActionResult RemoveMilitaryService(int userID, int serviceID)
        {
            if (!_profile.IsUserExist(userID))
                return StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
            if (!_profile.IsMilitaryServiceAdded(userID, serviceID))
                return StatusCode(404, new { status = "ВС с заданными параметрами не существует" });

            _profile.RemoveMilitaryService(userID, serviceID);
            return StatusCode(200, new { status = "Удаление ВС прошло успешно" });
        }

        #endregion



    }
}