using MyMovie.Domain.Models;

namespace MyMovie.Domain.Repositories;
public interface IDirectorRepository
{
    Task<IEnumerable<Director>> GetAllAsync();
    Task<Director> GetByIdAsync(int id);
    Task AddAsync(Director directory);
    Task UpdateAsync(Director directory);
    Task DeleteAsync(int id);
    Task<IEnumerable<Director>> GetByMovieIdAsync(int movieId);
}
