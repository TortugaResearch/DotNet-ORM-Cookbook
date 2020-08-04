using DevExpress.Xpo;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Recipes.Xpo.Entities;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Recipes.Xpo
{
    [TestClass]
    public class Setup
    {
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
        }

        [AssemblyInitialize]
        [SuppressMessage("Usage", "CA1801")]
        public static void AssemblyInit(TestContext context)
        {
            var configuration = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json").Build();

            ConnectionHelper.Connect(configuration, DevExpress.Xpo.DB.AutoCreateOption.DatabaseAndSchema);

            try
            {
                (new Setup()).Warmup_SqlServer();
            } catch { }
        }

        [TestMethod]
        public void CheckIncludes()
        {

            using (var uow = new UnitOfWork())
            {
                var e = new Employee(uow)
                {
                    EmployeeClassificationKey = 2,
                    FirstName = "test",
                    LastName = "test",
                };

                uow.CommitChanges();
            }
            using (var uow = new UnitOfWork())
            {
                var cl = uow.GetObjectByKey<EmployeeClassification>(2);
                Assert.AreNotEqual(0, cl.Employees.Count);
            }
        }

        [TestMethod]
        public void Warmup_SqlServer()
        {
            //Touch all of the models to warmup the UnitOfWork.
            using (var uow = new UnitOfWork())
            {
                uow.Query<Department>().FirstOrDefault();
                uow.Query<DepartmentDetail>().FirstOrDefault();
                uow.Query<Employee>().FirstOrDefault();
                uow.Query<EmployeeClassification>().FirstOrDefault();
            }
        }
    }
}

