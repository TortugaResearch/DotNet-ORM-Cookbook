using BenchmarkDotNet.Running;

namespace Performance
{
    static class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
