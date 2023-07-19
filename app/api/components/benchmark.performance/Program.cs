using benchmark.performance;
using BenchmarkDotNet.Running;

DateParser parser = new DateParser();
parser.GetYearFromSpanWithManualConversion("2019-12-13T16:33:06Z");

//BenchmarkRunner.Run<DateParserBenchmarks>();
//Console.ReadKey();