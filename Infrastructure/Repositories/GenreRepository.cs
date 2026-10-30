using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenreRepositories
{
    public async Task AddGenreAsync(Genre genre)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "INSERT INTO genres (name) VALUES (@name)";
        await connection.ExecuteAsync(query, genre);
    }

    public async Task DeleteGenreAsync(int id)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "delete from genres where id=@id";
        await connection.ExecuteAsync(query, new{id});
    }

    public async Task<Genre> GetGenreAsync(int id)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select * from genres where id=@id";
        var genre = await connection.QuerySingleAsync<Genre>(query, new{id});
        return genre;
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select * from genres";
        return (await connection.QueryAsync<Genre>(query)).ToList();
    }



    public async Task UpdateGenreAsync(Genre genre)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "update genres set name = @name where id=@id";
        await connection.ExecuteAsync(query, genre);
    }
    public async Task<int> GetGenresAmountAsync()
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select count(*) from genres";
        return await connection.ExecuteScalarAsync<int>(query);
    }
}