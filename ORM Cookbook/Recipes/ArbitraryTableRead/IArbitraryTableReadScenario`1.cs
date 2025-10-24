namespace Recipes.ArbitraryTableRead;

public interface IArbitraryTableReadScenario<T>
{
    T GetAll(string schema, string tableName);
}