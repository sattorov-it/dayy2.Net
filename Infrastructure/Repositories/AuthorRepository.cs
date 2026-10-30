using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorReporisotories
{
    public async Task AddAuthorAsync(Author author)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "INSERT INTO authors (fullname, country, birthyear) VALUES (@fullname, @country, @birthyear)";
        await connection.ExecuteAsync(query, author);
    }

    public async Task DeleteAuthorAsync(int id)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = $"delete from authors where id = @id";
        await connection.ExecuteAsync(query, new{id});
    }

    public async Task<Author> GetAuthorAsync(int id)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = $"select * from authors where id = @id";
        var author = await connection.QuerySingleAsync<Author>(query, new{id});
        return author;
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = $"select * from authors";
        var author = await connection.QueryAsync<Author>(query);
        return author.ToList();
    }



    public async Task UpdateAuthorAsync(Author author)
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = $"update authors set fullname = @fullname, country = @country, birthyear = @birthyear where id = @id";
        await connection.ExecuteAsync(query, author);
    }
    public async Task<int> GetAuthorsAmountAsync()
    {
        using var connection = Database.Connection();
        await connection.OpenAsync();
        var query = "select count(*) from authors";
        return await connection.ExecuteScalarAsync<int>(query);
    }
}