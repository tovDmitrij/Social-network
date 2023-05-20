namespace api.v1.service.auth.Models
{
    /// <summary>
    /// Refresh-токен пользователя
    /// </summary>
    /// <param name="Value">Значение</param>
    /// <param name="Expires">Дата просрочки токена</param>
    /// <param name="Created">Дата создания токена</param>
    internal record RefreshToken(string Value, DateTime Expires, DateTime Created);
}