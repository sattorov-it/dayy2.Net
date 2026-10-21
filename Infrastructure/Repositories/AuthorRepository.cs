using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    public void AddAuthor(Author author)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"insert into authors(fullname, country, birthyear) values('{author.Fullname}', '{author.Country}', {author.BirthYear})";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Added author successfully!");
    }

    public void DeleteAuthor(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"delete from authors where id={id}";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Deleted!");
    }

    public Author GetAuthor(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select id, fullname, country, birthyear from authors where id={id}";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        var author = new Author();
        while (data.Read())
        {
            author.Id = data.GetInt32(0);
            author.Fullname = data.GetString(1);
            author.Country = data.GetString(2);
            author.BirthYear = data.GetInt32(3);
        }
        return author;
    }

    public List<Author> GetAuthors()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id, fullname, country, birthyear from authors";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        var authors = new List<Author>();
        while (data.Read())
        {
            var author = new Author();
            author.Id = data.GetInt32(0);
            author.Fullname = data.GetString(1);
            author.Country = data.GetString(2);
            author.BirthYear = data.GetInt32(3);
            authors.Add(author);
        }
        return authors;
    }

    public void UpdateAuthor(Author author)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"update authors set fullname='{author.Fullname}', country='{author.Country}', birthyear={author.BirthYear} where id={author.Id}";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Updated!");
    }
}