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

        public TResult Execute<TResult>(Func<IDbConnection, TResult> action)
        {
            TResult result;
            using (var con = _connection.EnsureOpen())
            {
                try
                {
                    result = action(_connection);
                }
                catch (Exception e)
                {
                    throw;
                }
                finally
                {
                    _connection.Close();
                }
            }

            return result;
        }

        public async Task<TResult> ExecuteAsync<TResult>(Func<IDbConnection, Task<TResult>> action)
        {
            TResult result;
            using (var connection = await _connection.EnsureOpenAsync())
            {
                try
                {
                    result = await action(connection);
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

            return result;
        }
    }
}