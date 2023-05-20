using db.v1.context.dictionary.Repos.FamilyStatuses;
using db.v1.context.dictionary.Repos.Languages;
using db.v1.context.dictionary.Repos.LifePositions;
using db.v1.context.dictionary.Repos.Places;
namespace db.v1.context.dictionary.Wrappers
{
    /// <summary>
    /// Взаимодействие с БД-справочником
    /// </summary>
    public interface IDictionaryWrapper
    {
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