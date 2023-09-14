namespace api.v1.service.main.Exceptions
{
    public sealed class BadRequestException : APIException
    {
        public BadRequestException(string message) : base(400, message) { }
    }
}