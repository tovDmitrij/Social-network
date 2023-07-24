namespace api.v1.service.main.Exceptions
{
    public sealed class UnauthorizedException : APIException
    {
        public UnauthorizedException(string message) : base(401, message) { }
    }
}