using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
namespace benchmark.performance
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class DateParserBenchmarks
    {
        private const string DateTime = "2019-12-13T16:33:06Z";
        private static readonly DateParser parser = new DateParser();

        [Benchmark]
        public void GetYearFromDateTime()
        {
            parser.GetYearFromDateTime(DateTime);
        }

        [Benchmark]
        public void GetYearFromSplit()
        {
            parser.GetYearFromSplit(DateTime);
        }

        [Benchmark]
        public void GetYearFromSubstring()
        {
            parser.GetYearFromSubstring(DateTime);
        }

        [Benchmark]
        public void GetYearFromSpan()
        {
            parser.GetYearFromSpan(DateTime);
        }

        [Benchmark]
        public void GetYearFromSpanWithManualConversion()
        {
            parser.GetYearFromSpanWithManualConversion(DateTime);
        }
    }
}