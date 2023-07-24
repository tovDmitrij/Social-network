namespace api.v1.service.main.Exceptions
{
    public sealed class ValidationException : APIException
    {
        public ValidationException(string message) : base(400, message) { }
    }
}