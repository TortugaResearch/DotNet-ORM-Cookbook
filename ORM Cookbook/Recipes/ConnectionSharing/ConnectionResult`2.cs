using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.ConnectionSharing;

public class ConnectionResult<TConnection, TState>

where TConnection : DbConnection
{
    public ConnectionResult(TConnection connection, TState state)
    {
        Connection = connection;
        State = state;
    }

    public TConnection Connection { get; set; }
    public TState State { get; set; }

    public void Deconstruct(out TConnection connection, out TState state)
    {
        connection = Connection;
        state = State;
    }

    [SuppressMessage("Usage", "CA2225")]
    public static implicit operator ConnectionResult<TConnection, TState>(
        (TConnection connection, TState state) value)

    {
        return new ConnectionResult<TConnection, TState>(value.connection, value.state);
    }
}