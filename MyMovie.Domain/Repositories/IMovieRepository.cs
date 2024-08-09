using MyMovie.Domain.Models;

namespace MyMovie.Domain.Repositories;
public interface IMovieRepository
{
    Task<Movie> GetByIdAsync(int id);
    Task<IEnumerable<Movie>> GetAllAsync();
    Task AddAsync(Movie movie);
    void Update(Movie movie);
    void Delete(Movie movie);
}