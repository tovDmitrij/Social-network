using database.context.Models.Auth;
using misc.security;
namespace database.context.Repos.User
{
    public sealed class AuthRepos : IAuthRepos
    {
        private readonly DataContext _db;

        public AuthRepos(DataContext db) => _db = db;

        public void Add(string email, string password, string surname, string name, string? patronymic)
        {
            _db.Users.Add(new(
                email,
                Security.HashPassword(email, password)));
            _db.SaveChanges();

            _db.TableProfileBaseInfo.Add(new(
                GetByEmail(email).ID,
                surname,
                name,
                patronymic));
            _db.SaveChanges();
        }

        public UserAuthModel? GetByEmail(string email) => _db.Users
            .FirstOrDefault(user =>
                user.Email == email);

        public UserAuthModel? GetByEmailAndPassword(string email, string password) => _db.Users
            .FirstOrDefault(user =>
                user.Email == email && user.Password == Security.HashPassword(email, password));
    }
}