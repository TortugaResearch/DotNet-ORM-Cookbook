using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;

namespace Recipes.Xpo.Entities
{

    [Persistent(@"HR.Division")]
    public partial class Division : XPLiteObject
    {

        int fDivisionKey;
        [Key(true)]
        public int DivisionKey
        {
            get { return fDivisionKey; }
            set { SetPropertyValue<int>(nameof(DivisionKey), ref fDivisionKey, value); }
        }

        Guid fDivisionId;
        [ColumnDbDefaultValue("(newsequentialid())")]
        public Guid DivisionId
        {
            get { return fDivisionId; }
            set { SetPropertyValue<Guid>(nameof(DivisionId), ref fDivisionId, value); }
        }

        string? fDivisionName;
        [Indexed(Name = @"UX_Division_DivisionName", Unique = true)]
        [Size(30)]
        public string? DivisionName
        {
            get { return fDivisionName; }
            set { SetPropertyValue<string?>(nameof(DivisionName), ref fDivisionName, value); }
        }

        DateTime fCreatedDate;
        [ColumnDbDefaultValue("(sysutcdatetime())")]
        public DateTime CreatedDate
        {
            get { return fCreatedDate; }
            set { SetPropertyValue<DateTime>(nameof(CreatedDate), ref fCreatedDate, value); }
        }

        DateTime fModifiedDate;
        [ColumnDbDefaultValue("(sysutcdatetime())")]
        public DateTime ModifiedDate
        {
            get { return fModifiedDate; }
            set { SetPropertyValue<DateTime>(nameof(ModifiedDate), ref fModifiedDate, value); }
        }

        Employee fCreatedByEmployee;
        [Association(@"DivisionReferencesEmployee")]
        [Persistent("CreatedByEmployeeKey")]
        public Employee CreatedByEmployee
        {
            get { return fCreatedByEmployee; }
            set { SetPropertyValue<Employee>(nameof(CreatedByEmployee), ref fCreatedByEmployee, value); }
        }

        Employee fModifiedByEmployee;
        [Association(@"DivisionReferencesEmployee1")]
        [Persistent("ModifiedByEmployeeKey")]
        public Employee ModifiedByEmployee
        {
            get { return fModifiedByEmployee; }
            set { SetPropertyValue<Employee>(nameof(ModifiedByEmployee), ref fModifiedByEmployee, value); }
        }

        decimal? fSalaryBudget;
        public decimal? SalaryBudget
        {
            get { return fSalaryBudget; }
            set { SetPropertyValue<decimal?>(nameof(SalaryBudget), ref fSalaryBudget, value); }
        }

        decimal? fFteBudget;
        public decimal? FteBudget
        {
            get { return fFteBudget; }
            set { SetPropertyValue<decimal?>(nameof(FteBudget), ref fFteBudget, value); }
        }

        decimal? fSuppliesBudget;
        public decimal? SuppliesBudget
        {
            get { return fSuppliesBudget; }
            set { SetPropertyValue<decimal?>(nameof(SuppliesBudget), ref fSuppliesBudget, value); }
        }

        float? fFloorSpaceBudget;
        public float? FloorSpaceBudget
        {
            get { return fFloorSpaceBudget; }
            set { SetPropertyValue<float?>(nameof(FloorSpaceBudget), ref fFloorSpaceBudget, value); }
        }

        int? fMaxEmployees;
        public int? MaxEmployees
        {
            get { return fMaxEmployees; }
            set { SetPropertyValue<int?>(nameof(MaxEmployees), ref fMaxEmployees, value); }
        }

        DateTimeOffset? lastReviewCycle;
        [ValueConverter(typeof(DateTimeOffsetConverter))]
        [DbType("datetimeoffset")]
        public DateTimeOffset? LastReviewCycle
        {
            get { return lastReviewCycle; }
            set { SetPropertyValue(nameof(LastReviewCycle), ref lastReviewCycle, value); }
        }

        TimeSpan? startTime;
        [ValueConverter(typeof(Time7Converter))]
        [DbType("time(7)")]
        public TimeSpan? StartTime
        {
            get { return startTime; }
            set { SetPropertyValue(nameof(StartTime), ref startTime, value); }
        }



        [Association(@"DepartmentReferencesDivision")]
        public XPCollection<Department> Departments { get { return GetCollection<Department>(nameof(Departments)); } }

        public Division(Session session) : base(session) { }
    }

}
