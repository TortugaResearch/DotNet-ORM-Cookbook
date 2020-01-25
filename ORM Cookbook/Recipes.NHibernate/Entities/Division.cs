using System;

namespace Recipes.NHibernate.Entities
{
    public class Division : IDivision
    {
        public virtual int CreatedByEmployeeKey { get; set; }

        public virtual DateTime CreatedDate { get; set; }

        public virtual Guid DivisionId { get; set; }

        public virtual int DivisionKey { get; set; }

        public virtual string? DivisionName { get; set; }

        public virtual float? FloorSpaceBudget { get; set; }

        public virtual decimal? FteBudget { get; set; }

        public virtual DateTimeOffset? LastReviewCycle { get; set; }
        public virtual int? MaxEmployees { get; set; }
        public virtual int ModifiedByEmployeeKey { get; set; }

        public virtual DateTime ModifiedDate { get; set; }

        public virtual decimal? SalaryBudget { get; set; }

        public virtual TimeSpan? StartTime { get; set; }

        public virtual decimal? SuppliesBudget { get; set; }
    }
}
