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



        #region Аккаунты

        public bool IsAccountExist(string email, string password) => _db.TableUsers
            .Any(user => user.Email == email && user.Password == Security.HashPassword(email, password));

        public bool IsEmailBusy(string email) => _db.TableUsers
            .Any(user => user.Email == email);

        public int AddAccount(string email, string password)
        {
            var account = new UserModel(email, Security.HashPassword(email, password));
            _db.TableUsers.Add(account);
            _db.SaveChanges();
            return account.ID;
        }

        public UserViewModel? GetAccountInfo(string email, string password) => _db.ViewUsers
            .FirstOrDefault(user => user.Email == email && user.Password == Security.HashPassword(email, password));

        public UserViewModel? GetAccountInfo(int id) => _db.ViewUsers
            .FirstOrDefault(user => user.ID == id);

        #endregion



        #region Токены

        public bool IsTokenExist(int userID, string token) => _db.TableTokens
            .Any(t => t.RefreshToken == token && t.UserID == userID);

        public bool IsTokenExpired(int userID, string token) => _db.TableTokens
            .First(t => t.RefreshToken == token && t.UserID == userID).ExpireDate > DateTime.Now ? true : false;

        public void AddToken(UserTokenModel token)
        {
            switch (IsTokenExist(token.UserID, token.RefreshToken))
            {
                case true:
                    _db.TableTokens.Update(token);
                    _db.SaveChanges();
                    break;

                case false:
                    _db.TableTokens.Add(token);
                    _db.SaveChanges();
                    break;
            }
        }

        public UserTokenModel? GetToken(string token) => _db.TableTokens
            .FirstOrDefault(t => t.RefreshToken == token);

        #endregion



    }
}