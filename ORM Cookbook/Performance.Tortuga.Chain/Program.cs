using BenchmarkDotNet.Running;

namespace Performance.Tortuga.Chain
{
    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
