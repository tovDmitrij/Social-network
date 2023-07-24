namespace api.v1.service.main.Exceptions
{
    public abstract class APIException : Exception
    {
        public int StatusCode { get; }

        public APIException(int statusCode, string message) : base(message) => StatusCode = statusCode;
    }
}