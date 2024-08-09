using MyMovie.Domain.Models;
using MyMovie.Domain.Repositories;
using System.Data;
using Dapper;


namespace MyMovie.Infrastructure.Repositories;
// MyMovie.Infrastructure/Repositories/MovieRepository.cs
public class MovieRepository : IMovieRepository
{
    private readonly IDbConnection _connection;
    private readonly IDbTransaction _transaction;

    public MovieRepository(IDbConnection connection, IDbTransaction transaction)
    {
        _connection = connection;
        _transaction = transaction;
    }

    public async Task<Movie> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM tb_movie WHERE Id = @Id";
        return await _connection.QueryFirstOrDefaultAsync<Movie>(sql, new { Id = id }, _transaction);
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        var sql = "SELECT * FROM tb_movie";
        return await _connection.QueryAsync<Movie>(sql, transaction: _transaction);
    }

    public async Task AddAsync(Movie movie)
    {
        var sql = "INSERT INTO tb_movie (Id, Title, Genre, ReleaseDate) VALUES (@Id, @Title, @Genre, @ReleaseDate)";
        await _connection.ExecuteAsync(sql, movie, _transaction);
    }

    public void Update(Movie movie)
    {
        var sql = "UPDATE tb_movie SET Title = @Title, Genre = @Genre, ReleaseDate = @ReleaseDate WHERE Id = @Id";
        _connection.Execute(sql, movie, _transaction);
    }

    public void Delete(Movie movie)
    {
        var sql = "DELETE FROM tb_movie WHERE Id = @Id";
        _connection.Execute(sql, new { movie.Id }, _transaction);
    }
}

