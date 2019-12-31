using BenchmarkDotNet.Attributes;
using Recipes.EntityFrameworkCore.TryCrud;

namespace Performance
{
    partial class Benchmarks
    {
        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_UpdateWithStatus_Pass()
        {
            var test = new TryCrudTests();
            test.UpdateWithStatus_Pass();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_UpdateWithStatus_Fail()
        {
            var test = new TryCrudTests();
            test.UpdateWithStatus_Fail();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_UpdateOrException_Pass()
        {
            var test = new TryCrudTests();
            test.UpdateOrException_Pass();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_UpdateOrException_Fail()
        {
            var test = new TryCrudTests();
            test.UpdateOrException_Fail();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_DeleteByKeyOrException()
        {
            var test = new TryCrudTests();
            test.DeleteByKeyOrException();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_DeleteByKeyWithStatus()
        {
            var test = new TryCrudTests();
            test.DeleteByKeyWithStatus();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_DeleteOrException()
        {
            var test = new TryCrudTests();
            test.DeleteOrException();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_DeleteWithStatus()
        {
            var test = new TryCrudTests();
            test.DeleteWithStatus();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_FindByNameOrException_Fail()
        {
            var test = new TryCrudTests();
            test.FindByNameOrException_Fail();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_FindByNameOrException_Pass()
        {
            var test = new TryCrudTests();
            test.FindByNameOrException_Pass();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_FindByNameOrNull_Fail()
        {
            var test = new TryCrudTests();
            test.FindByNameOrNull_Fail();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_FindByNameOrNull_Pass()
        {
            var test = new TryCrudTests();
            test.FindByNameOrNull_Pass();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_GetByKeyOrException_Fail()
        {
            var test = new TryCrudTests();
            test.GetByKeyOrException_Fail();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_GetByKeyOrException_Pass()
        {
            var test = new TryCrudTests();
            test.GetByKeyOrException_Pass();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_GetByKeyOrNull_Fail()
        {
            var test = new TryCrudTests();
            test.GetByKeyOrNull_Fail();
        }

        [Benchmark]
        public void EntityFrameworkCore_TryCrudTests_GetByKeyOrNull_Pass()
        {
            var test = new TryCrudTests();
            test.GetByKeyOrNull_Pass();
        }
    }
}
