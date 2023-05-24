using db.v1.context.profiles.Repos.FamilyStatuses;
using db.v1.context.profiles.Repos.Languages;
using db.v1.context.profiles.Repos.LifePositions;
using db.v1.context.profiles.Repos.Places;
using db.v1.context.profiles.Repos.Profiles;
namespace db.v1.context.profiles.Wrappers
{
    /// <summary>
    /// Взаимодействие с БД профилей пользователей
    /// </summary>
    public interface IProfileWrapper
    {
        /// <summary>
        /// Взаимодействие с таблицей профилей пользователей
        /// </summary>
        public IProfileRepos Profiles { get; }

        /// <summary>
        /// Взаимодействие с таблицей семейных положений
        /// </summary>
        public IFamilyStatusRepos Families { get; }

        /// <summary>
        /// Взаимодействие с таблицей языков платформы
        /// </summary>
        public ILanguageRepos Langs { get; }

        /// <summary>
        /// Взаимодействие с таблицей жизненных позиций
        /// </summary>
        public ILifePositionRepos Positions { get; }

        /// <summary>
        /// Взаимодействие с таблицами городов, регионов и стран мира
        /// </summary>
        public IPlaceRepos Places { get; }
    }
}