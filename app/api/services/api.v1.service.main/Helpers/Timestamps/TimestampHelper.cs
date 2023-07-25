namespace api.v1.service.main.Helpers.Timestamps
{
    public sealed class TimestampHelper : ITimestampHelper
    {
        public decimal GetCurrentTimestamp() => (decimal)DateTime.UtcNow.Subtract(DateTime.Parse("1970-01-01")).TotalSeconds;
    }
}