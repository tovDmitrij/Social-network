using db.v1.context.auth.Models;
using misc.security;
namespace db.v1.context.auth.Repos
{
    public sealed class AuthRepos : IAuthRepos
    {
        /// <summary>
        /// База данных аккаунтов пользователей
        /// </summary>
        private readonly AuthContext _db;

        public AuthRepos(AuthContext db) => _db = db;

        public bool IsAccountExist(string email, string password) => _db.TableUsers
            .Any(user => user.Email == email && user.Password == Security.HashPassword(email, password));

        public bool IsEmailBusy(string email) => _db.TableUsers
            .Any(user => user.Email == email);

        public void Add(string email, string password)
        {
            _db.TableUsers.Add(new(email, Security.HashPassword(email, password)));
            _db.SaveChanges();
        }

        public UserViewModel? GetAccountInfo(string email, string password) => _db.ViewUsers
            .FirstOrDefault(user => user.Email == email && user.Password == Security.HashPassword(email, password));
    }
}