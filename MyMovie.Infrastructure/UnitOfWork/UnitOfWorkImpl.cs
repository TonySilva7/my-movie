using MyMovie.Domain.Repositories;
using MyMovie.Domain.UnitOfWork;
using MyMovie.Infrastructure.Repositories;
using System.Data;

namespace MyMovie.Infrastructure.UnitOfWork
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        private IMovieRepository? _movieRepository;

        public UnitOfWorkImpl(IDbConnection connetion)
        {
            _connection = connetion;
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IMovieRepository Movies
        {
            get { return _movieRepository ??= new MovieRepository(_connection, _transaction); }
        }

        public async Task CommitAsync()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
            finally
            {
                await DisposeAsync();
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection?.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            Dispose();
            await Task.CompletedTask;
        }
    }
}
