using database.context.Models;
using misc.security;
namespace database.context.Repos
{
    /// <summary>
    /// Взаимодействие с пользователем в системе
    /// </summary>
    public sealed class UserRepository : IUserRepository
    {
        /// <summary>
        /// База данных социальной сети
        /// </summary>
        private readonly DataContext _db;

        public UserRepository(DataContext db) => _db = db;

        public void Add(UserModel user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public void Delete(UserModel user)
        {
            _db.Users.Remove(user);
            _db.SaveChanges();
        }

        public UserModel? GetByEmail(string email) => 
            _db.Users.FirstOrDefault(user =>
                user.Email == email);

        public UserModel? GetByEmailAndPassword(string email, string password) =>
            _db.Users.FirstOrDefault(user =>
                user.Email == email &&
                user.Password == Security.ToSHA512(password));

        public UserModel? GetByID(int id) => 
            _db.Users.FirstOrDefault(user =>
                user.ID == id);
    }
}