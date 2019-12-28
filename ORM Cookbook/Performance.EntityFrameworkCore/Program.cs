using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Recipes.EntityFrameworkCore;
using Recipes.EntityFrameworkCore.SingleModelCrud;
using System;

namespace Performance.EntityFrameworkCore
{
    class Program
    {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
