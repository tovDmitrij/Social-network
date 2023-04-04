using database.context.main.Models.Data;
namespace database.context.main.Repos.Cities
{
    /// <summary>
    /// Взаимодействие с таблицами городов, регионов и стран мира
    /// </summary>
    public interface IPlaceOfLivingRepos
    {



        #region Города

        /// <summary>
        /// Метод, проверяющий существование города по его идентификатору
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        public bool IsCityExist(int cityID);

        /// <summary>
        /// Метод, проверяющий наличие города с заданным идентификатором в регионе
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="regionID">Идентификатор региона</param>
        public bool IsCityExistInRegion(int cityID, int regionID);

        /// <summary>
        /// Метод, проверяющий наличие города с заданным идентификатором в стране
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        /// <param name="countryID">Идентификатор страны</param>
        public bool IsCityExistInCountry(int cityID, int countryID);

        /// <summary>
        /// Получить информацию по городу по его идентификатору
        /// </summary>
        /// <param name="cityID">Идентификатор города</param>
        public CityModel? GetCity(int cityID);

        /// <summary>
        /// Получить список городов
        /// </summary>
        public IEnumerable<CityModel>? GetCities();

        /// <summary>
        /// Получить список городов по идентификатору региона
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        public IEnumerable<CityModel>? GetCitiesByRegion(int regionID);

        /// <summary>
        /// Получить список городов по идентификатору страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        public IEnumerable<CityModel>? GetCitiesByCountry(int countryID);

        #endregion



        #region Регионы

        /// <summary>
        /// Метод, проверяющий существование региона с заданным идентификатором
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        public bool IsRegionExist(int regionID);

        /// <summary>
        /// Метод, проверяющий наличие региона в стране с заданным идентификатором
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        /// <param name="countryID">Идентификатор страны</param>
        public bool IsRegionExistInCountry(int regionID, int countryID);

        /// <summary>
        /// Получить информацию по региону по его идентификатору
        /// </summary>
        /// <param name="regionID">Идентификатор региона</param>
        public RegionModel? GetRegion(int regionID);

        /// <summary>
        /// Получить список регионов
        /// </summary>
        public IEnumerable<RegionModel>? GetRegions();

        /// <summary>
        /// Получить список регионов по идентификатору страны
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        public IEnumerable<RegionModel>? GetRegionsByCountry(int countryID);

        #endregion



        #region Страны

        /// <summary>
        /// Метод, проверяющий существование страны по её идентификатору
        /// </summary>
        /// <param name="countryID">Идентификатор страны</param>
        public bool IsCountryExist(int countryID);

        /// <summary>
        /// Получить информацию по стране по её идентификатору
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