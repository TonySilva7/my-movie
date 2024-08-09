using MyMovie.Domain.Models;

namespace MyMovie.Application.UseCases;
public interface IMovieUseCase
{
    Task<IEnumerable<Movie>> Execute();
}
