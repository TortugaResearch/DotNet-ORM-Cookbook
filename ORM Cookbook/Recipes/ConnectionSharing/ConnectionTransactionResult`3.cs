using System.Data.Common;
using System.Diagnostics.CodeAnalysis;

namespace Recipes.ConnectionSharing;

public class ConnectionTransactionResult<TConnection, TTransaction, TState>

where TConnection : DbConnection
where TTransaction : DbTransaction
{
    public ConnectionTransactionResult(TConnection connection, TTransaction transaction, TState state)
    {
        Connection = connection;
        State = state;
        Transaction = transaction;
    }

    public TConnection Connection { get; set; }
    public TTransaction Transaction { get; set; }
    public TState State { get; set; }

    public void Deconstruct(out TConnection connection, out TTransaction transaction, out TState state)
    {
        connection = Connection;
        transaction = Transaction;
        state = State;
    }

    [SuppressMessage("Usage", "CA2225")]
    public static implicit operator ConnectionTransactionResult<TConnection, TTransaction, TState>
        ((TConnection connection, TTransaction transaction, TState state) value)

    {
        return new ConnectionTransactionResult<TConnection, TTransaction, TState>
                    (value.connection, value.transaction, value.state);
    }
}
