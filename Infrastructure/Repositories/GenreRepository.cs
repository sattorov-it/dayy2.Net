using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    public void AddGenre(Genre genre)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "insert into genres(name) values (@name)";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("name", genre.Name);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Added!");
    }

    public void DeleteGenre(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "delete from genres where id=@id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Deleted!");
    }

    public Genre GetGenre(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id, name from genres where id=@id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        var data = cmd.ExecuteReader();
        var genre = new Genre();
        while (data.Read())
        {
            genre.Id = data.GetInt32(0);
            genre.Name = data.GetString(1);
        }
        return genre;
    }

    public List<Genre> GetGenres()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id, name from genres";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        var genres = new List<Genre>();
        while (data.Read())
        {
            var genre = new Genre();
            genre.Id = data.GetInt32(0);
            genre.Name = data.GetString(1);
            genres.Add(genre);
        }
        return genres;
    }

    public void UpdateGenre(Genre genre)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "update genres set name=@name where id=@id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("name", genre.Name);
        cmd.Parameters.AddWithValue("id", genre.Id);
        var reader = cmd.ExecuteReader();
        Genre genre1 = new();
        while(reader.Read())
        {
            genre1.Id = genre.Id;
            genre1.Name = genre.Name;
        }
    }
}