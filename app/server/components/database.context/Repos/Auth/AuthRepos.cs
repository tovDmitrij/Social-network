using database.context.Models.Auth;
using misc.security;
namespace database.context.Repos.User
{
    public sealed class AuthRepos : BaseRepos, IAuthRepos
    {
        public AuthRepos(DataContext db) : base(db) { }

        public bool IsAccountExist(string email, string password) => _db.TableUsers
            .Any(user => user.Email == email && user.Password == Security.HashPassword(email, password));

        public bool IsEmailBusy(string email) => _db.TableUsers
            .Any(user => user.Email == email);

        public void Add(string email, string password, string surname, string name, string? patronymic)
        {
            _db.TableUsers.Add(new(
                email,
                Security.HashPassword(email, password)));
            _db.SaveChanges();

            _db.TableProfileBaseInfo.Add(new(
                GetAccountInfo(email, password).ID,
                surname,
                name,
                patronymic));
            _db.SaveChanges();
        }

        public UserAuthModel? GetAccountInfo(string email, string password) => _db.TableUsers
            .FirstOrDefault(user =>
                user.Email == email && user.Password == Security.HashPassword(email, password));
    }
}