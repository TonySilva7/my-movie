using MyMovie.Domain.Models;
using MyMovie.Domain.UnitOfWork;

namespace MyMovie.Application.UseCases;
public class MovieUseCase : IMovieUseCase
{
    public IUnitOfWork uof;
    public MovieUseCase(IUnitOfWork uof) {
        this.uof = uof;
    }

    public async Task<IEnumerable<Movie>> Execute()
    {
        var movies = await uof.Movies.GetAllAsync();

        return movies;
    }
}