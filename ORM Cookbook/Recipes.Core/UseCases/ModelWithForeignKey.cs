using Recipes.Models;
using Recipes.Repositories;
using System;
using Xunit;

namespace Recipes.UseCases
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModelWithForeignKey<TDepartment>
        where TDepartment : IDepartment, new()
    {
        [Fact]
        public abstract void CreateAndUpdate();

        public void CreateAndUpdate(ISimpleDepartmentRepository<TDepartment> repository)
        {
            const int originalDivision = 1;
            const int updatedDivision = 2;

            var newDepartment = new TDepartment();
            newDepartment.DepartmentName = "Test " + DateTime.Now.Ticks;
            newDepartment.DivisionKey = originalDivision;

            var newKey = repository.Create(newDepartment);

            //Verify the insert worked
            var department1 = repository.GetByKey(newKey);
            Assert.Equal(newKey, department1.DepartmentKey);
            Assert.Equal(newDepartment.DepartmentName, department1.DepartmentName);
            Assert.Equal(newDepartment.DivisionKey, department1.DivisionKey);

            //Change the division
            department1.DivisionKey = updatedDivision;
            repository.Update(department1);

            //Verify the update worked
            var department2 = repository.GetByKey(newKey);
            Assert.Equal(newKey, department2.DepartmentKey);
            Assert.Equal(department1.DepartmentName, department2.DepartmentName);
            Assert.Equal(department1.DivisionKey, department2.DivisionKey);


        }
    }
}
