namespace api.v1.service.main.DTOs.Users
{
    public sealed record TokenDTO(string access_token, string refresh_token);
}