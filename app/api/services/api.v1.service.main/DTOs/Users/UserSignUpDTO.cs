namespace api.v1.service.main.DTOs.Users
{
    public sealed record UserSignUpDTO(string email, string password, string surname, string name);
}