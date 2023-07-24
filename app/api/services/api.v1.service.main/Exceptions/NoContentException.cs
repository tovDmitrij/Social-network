namespace api.v1.service.main.Exceptions
{
    public sealed class NoContentException : APIException
    {
        public NoContentException(string message) : base(204, message) { }
    }
}