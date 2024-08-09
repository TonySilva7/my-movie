using MyMovie.Domain.Models;
using MyMovie.Domain.Repositories;

namespace MyMovie.Domain.UnitOfWork;
public interface IUnitOfWork : IDisposable
{
    IMovieRepository Movies { get; }
    Task CommitAsync();

}
