using Recipes.Models;
using Recipes.Repositories;
using System;
using System.Linq;
using Xunit;

namespace Recipes.UseCases
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ModelWithSingleChild<TDepartment, TDivision>
        where TDepartment : IDepartment<TDivision>, new()
        where TDivision : IDivision, new()

    {
        [Fact]
        public abstract void CreateAndUpdate();

        public void CreateAndUpdate(IDepartmentWithChildRepository<TDepartment, TDivision> repository)
        {
            const int originalDivision = 1;
            const int updatedDivision = 2;


            var divisions = repository.GetAllDivisions();

            var newDepartment = new TDepartment();
            newDepartment.DepartmentName = "Test " + DateTime.Now.Ticks;
            newDepartment.Division = divisions.Single(d => d.DivisionKey == originalDivision);

            var newKey = repository.Create(newDepartment);

            //Verify the insert worked
            var department1 = repository.GetByKey(newKey);
            Assert.Equal(newKey, department1.DepartmentKey);
            Assert.Equal(newDepartment.DepartmentName, department1.DepartmentName);
            Assert.Equal(newDepartment.Division.DivisionKey, department1.Division.DivisionKey);
            Assert.Equal(newDepartment.Division.DivisionName, department1.Division.DivisionName);

            //Change the division
            department1.Division = divisions.Single(d => d.DivisionKey == updatedDivision);
            repository.Update(department1);

            //Verify the update worked
            var department2 = repository.GetByKey(newKey);
            Assert.Equal(newKey, department2.DepartmentKey);
            Assert.Equal(department1.DepartmentName, department2.DepartmentName);
            Assert.Equal(department1.Division.DivisionKey, department2.Division.DivisionKey);
            Assert.Equal(department1.Division.DivisionName, department2.Division.DivisionName);

        }

    }
}


