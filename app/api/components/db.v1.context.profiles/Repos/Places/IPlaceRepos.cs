using db.v1.context.profiles.Models.Dictionary.Places;
namespace db.v1.context.profiles.Repos.Places
{
    /// <summary>
    /// Взаимодействие с таблицами городов, регионов и стран мира
    /// </summary>
    public interface IPlaceRepos
    {



        #region Города

        /// <summary>
        /// Метод, проверяющий существование города
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        public bool IsCityExist(int cityID);

        /// <summary>
        /// Метод, проверяющий существование города в регионе
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="regionID">Идентификатор региона</param>
        public bool IsCityExistInRegion(int cityID, int regionID);

        /// <summary>
        /// Метод, проверяющий существование города в стране
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="countryID">Идентификатор страны</param>
        public bool IsCityExistInCountry(int cityID, int countryID);

        /// <summary>
        /// Получить информацию о городе
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        public CityModel? GetCity(int cityID);

        /// <summary>
        /// Получить список городов
        /// </summary>
        public IEnumerable<CityModel>? GetCities();

        /// <summary>
        /// Получить список городов региона
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        public IEnumerable<CityModel>? GetCitiesByRegion(int regionID);

        /// <summary>
        /// Получить список городов страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        public IEnumerable<CityModel>? GetCitiesByCountry(int countryID);

        #endregion



        #region Регионы

        /// <summary>
        /// Метод, проверяющий существование региона
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        public bool IsRegionExist(int regionID);

        /// <summary>
        /// Метод, проверяющий существование региона в стране
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        /// <param name="countryID">Идентификатор страны</param>
        public bool IsRegionExistInCountry(int regionID, int countryID);

        /// <summary>
        /// Получить информацию о регионе
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        public RegionModel? GetRegion(int regionID);

        /// <summary>
        /// Получить список регионов
        /// </summary>
        public IEnumerable<RegionModel>? GetRegions();

        /// <summary>
        /// Получить список регионов страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        public IEnumerable<RegionModel>? GetRegionsByCountry(int countryID);

        #endregion



        #region Страны

        /// <summary>
        /// Метод, проверяющий существование страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        public bool IsCountryExist(int countryID);

        /// <summary>
        /// Получить информацию о стране
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        public CountryModel? GetCountry(int countryID);

        /// <summary>
        /// Получить список стран
        /// </summary>
        public IEnumerable<CountryModel>? GetCountries();

        #endregion



    }
}