namespace api.v1.service.main.Helpers.JWT
{
    public interface IJWTHelper
    {
        public Guid GetUserID(string token);
    }
}