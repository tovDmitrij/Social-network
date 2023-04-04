using Microsoft.AspNetCore.Mvc;
namespace api.Controllers
{
    /// <summary>
    /// Базовый контроллер API социальной сети
    /// </summary>
    public class BaseController : ControllerBase
    {



        #region 200

        protected IActionResult SignUpOk => StatusCode(200, new { status = "Новый аккаунт был успешно зарегистрирован" });
        protected IActionResult SignInOk(int userID, string token) => StatusCode(200, new { status = "Аккаунт был успешно найден", id = userID, token });

        protected IActionResult ProfileBaseInfoOk(dynamic data) => StatusCode(200, new { status = "Базовая информация о профиле пользователе была успешно сформирована", data });
        protected IActionResult ProfileLanguageAddOk => StatusCode(200, new { status = "Новый язык был успешно добавлен в профиль пользователя" });
        protected IActionResult ProfileLanguageDeleteOk => StatusCode(200, new { status = "Удаление языка из профиля пользователя прошло успешно" });
        protected IActionResult ProfileLanguagesOk(dynamic data) => StatusCode(200, new { status = "Список языков пользователя был успешно сформирован", data });
        protected IActionResult ProfileLifePositionAddOk => StatusCode(200, new { status = "Новая жизненная позиция была успешно добавлена" });
        protected IActionResult ProfileLifePositionDeleteOk => StatusCode(200, new { status = "Удаление жизненной позиции прошло успешно" });
        protected IActionResult ProfileLifePositionsOk(dynamic data) => StatusCode(200, new { status = "Список жизненных позиций был успешно сформирован", data });

        protected IActionResult LanguageOk(dynamic data) => StatusCode(200, new { status = "Информация о языке была успешно сформирована", data });
        protected IActionResult LanguagesOk(dynamic data) => StatusCode(200, new { status = "Список языков был успешно сформирован", data });
       
        protected IActionResult LifePositionOk(dynamic data) => StatusCode(200, new { status = "Информация о жизненной позиции была успешно сформирована", data });
        protected IActionResult LifePositionsOk(dynamic data) => StatusCode(200, new { status = "Список жизненных позиций был успешно сформирован", data });
        
        protected IActionResult CityOk(dynamic data) => StatusCode(200, new { status = "Информация о городе была успешно сформирована", data });
        protected IActionResult CitiesOk(dynamic data) => StatusCode(200, new { status = "Список городов был успешно сформирован", data });
        
        protected IActionResult RegionOk(dynamic data) => StatusCode(200, new { status = "Информация о регионе была успешно сформирована", data });
        protected IActionResult RegionsOk(dynamic data) => StatusCode(200, new { status = "Список регионов был успешно сформирован", data });
        
        protected IActionResult CountryOk(dynamic data) => StatusCode(200, new { status = "Информация о стране была успешно сформирована", data });
        protected IActionResult CountriesOk(dynamic data) => StatusCode(200, new { status = "Список стран был успешно сформирован", data });

        #endregion



        #region 404

        protected IActionResult SignInNotFound => StatusCode(404, new { status = "Аккаунта с заданной почтой и паролем не существует" });

        protected IActionResult UserNotFound => StatusCode(404, new { status = "Пользователя с заданным идентификатором не существует" });
        protected IActionResult ProfileLanguageNotFound => StatusCode(406, new { status = "У пользователя отсутствует заданный язык в списке языков" });
        protected IActionResult ProfileLanguagesNotFound => StatusCode(404, new { status = "У пользователя отсутствует список языков" });
        protected IActionResult ProfileLifePositionNotFound => StatusCode(406, new { status = "У пользователя отсутствует заданная жизненная позиция в списке жизненных позиций" });
        protected IActionResult ProfileLifePositionsNotFound => StatusCode(404, new { status = "У пользователя отсутствует список жизненных позиций" });

        protected IActionResult LanguageNotFound => StatusCode(404, new { status = "Языка с заданным идентификатором не существует" });
        protected IActionResult LanguagesNotFound => StatusCode(404, new { status = "Список языков пуст" });
        
        protected IActionResult LifePositionNotFound => StatusCode(404, new { status = "Жизненной позиции с заданным идентификатором не существует" });
        protected IActionResult LifePositionTypeNotFound => StatusCode(404, new { status = "Типа жизненной позиции с заданным идентификатором не существует" });
        protected IActionResult LifePositionByTypeNotFound => StatusCode(404, new { status = "Жизненной позиции в заданном типе не существует" });
        protected IActionResult LifePositionsNotFound => StatusCode(404, new { status = "Список жизненных позиций пуст" });
        protected IActionResult LifePositionsByTypeNotFound => StatusCode(404, new { status = "Список жизненных позиций заданного типа пуст" });
        
        protected IActionResult CityNotFound => StatusCode(404, new { status = "Города с заданным идентификатором не существует" });
        protected IActionResult CityInRegionNotFound => StatusCode(404, new { status = "Города в регионе с заданным идентификатором не существует" });
        protected IActionResult CityInCountryNotFound => StatusCode(404, new { status = "Города в стране с заданным идентификатором не существует" });
        protected IActionResult CitiesNotFound => StatusCode(404, new { status = "Список городов пуст" });
        protected IActionResult CitiesByRegionNotFound => StatusCode(404, new { status = "Список городов для заданного региона пуст" });
        protected IActionResult CitiesByCountryNotFound => StatusCode(404, new { status = "Список городов для заданной страны пуст" });
        
        protected IActionResult RegionNotFound => StatusCode(404, new { status = "Региона с заданным идентификатором не существует" });
        protected IActionResult RegionByCountryNotFound => StatusCode(404, new { status = "Региона в стране с заданным идентификатором не существует" });
        protected IActionResult RegionsNotFound => StatusCode(404, new { status = "Список регионов пуст" });
        protected IActionResult RegionsByCountryNotFound => StatusCode(404, new { status = "Список регионов для заданной страны пуст" });
        
        protected IActionResult CountryNotFound => StatusCode(404, new { status = "Страны с заданным идентификатором не существует" });
        protected IActionResult CountriesNotFound => StatusCode(404, new { status = "Список стран пуст" });

        #endregion



        #region 406

        protected IActionResult EmailIsNotAcceptable => StatusCode(406, new { status = "Почта уже занята другим пользователем" });
        protected IActionResult ProfileLanguageNotAcceptable => StatusCode(406, new { status = "Язык уже добавлен в список языков пользователя" });

        #endregion



    }
}