namespace api.v1.service.main.Helpers.Validators.Interfaces
{
    public interface IUserValidateHelper
    {
        public void ValidateEmail(string email);
        public void ValidatePassword(string password);
        public void ValidateFullname(string fullname);
    }
}