using System;
using System.Data;
using System.Threading.Tasks;
using RepoDb;

namespace JServiceStack.Database
{
    public class JDatabaseExecutor : IDisposable
    {
        private readonly IDbConnection _connection;

        public JDatabaseExecutor(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }

        public TResult Execute<TResult>(Func<IDbConnection, TResult> action,
            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            TResult result;
            using (var tran = _connection.EnsureOpen().BeginTransaction(isolationLevel))
            {
                try
                {
                    result = action(_connection);
                    tran.Commit();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw;
                }
                finally
                {
                    _connection.Close();
                }
            }

            return result;
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<IDbConnection, Task<TResult>> action,
            IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            TResult result;
            using (var connection = await _connection.EnsureOpenAsync())
            {
                using (var tran = connection.BeginTransaction(isolationLevel))
                {
                    try
                    {
                        result = await action(connection);
                        tran.Commit();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                    finally
                    {
                        _connection.Close();
                    }
                }
            }

            return result;
        }
    }
}