namespace Recipes.PartialUpdate
{
    /// <summary>
    /// This class is used to hold the fields used for a partial update.
    /// </summary>
    public class EmployeeClassificationFlagsUpdater
    {
        public int EmployeeClassificationKey { get; set; }
        public bool IsExempt { get; set; }
        public bool IsEmployee { get; set; }
    }
}
