﻿using database.context.Contexts;
using database.context.Models.Misc;
namespace database.context.Repos.Languages
{
    public sealed class LanguageRepos : BaseRepos, ILanguageRepos
    {
        public LanguageRepos(MainContext db) : base(db) { }

        public bool IsLanguageExist(int langID) => _db.TableLanguages
            .Any(language => language.ID == langID);

        public LanguageModel? GetLanguage(int langID) => _db.TableLanguages
            .FirstOrDefault(language => language.ID == langID);

        public IEnumerable<LanguageModel>? GetLanguages() => _db.TableLanguages
            .Select(language => language);
    }
}