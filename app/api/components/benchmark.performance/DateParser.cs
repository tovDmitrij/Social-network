namespace benchmark.performance
{
    public class DateParser
    {
        public int GetYearFromDateTime(string date)
        {
            var dateTime = DateTime.Parse(date);
            return dateTime.Year;
        }

        public int GetYearFromSplit(string date)
        {
            var split = date.Split('-');
            return int.Parse(split[0]);
        }

        public int GetYearFromSubstring(string date)
        {
            var index = date.IndexOf("-");
            return int.Parse(date.Substring(0, index));
        }

        public int GetYearFromSpan(ReadOnlySpan<char> date)
        {
            var index = date.IndexOf("-");
            return int.Parse(date.Slice(0, index));
        }

        public int GetYearFromSpanWithManualConversion(ReadOnlySpan<char> date)
        {
            var index = date.IndexOf("-");
            var year = date.Slice(0, index);

            var tmp = 0;
            for (int i = 0; i < year.Length; i++)
            {
                tmp = tmp * 10 + (year[i] - '0');
            }

            return tmp;
        }
    }
}