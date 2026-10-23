using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    public void AddBook(Book book)
    {
        using var connection = Database.Connection();
        connection.Open();
        var query = "insert into books(title, publishedyear, totalcopies, authorid, genreid) values(@title, @publishedyear, @totalcopies, @authorid, @genreid)";
        var cmd = new NpgsqlCommand(query, connection);
        cmd.Parameters.AddWithValue("title", book.Title);
        cmd.Parameters.AddWithValue("publishedyear", book.PublishedYear);
        cmd.Parameters.AddWithValue("totalcopies", book.TotalCopies);
        cmd.Parameters.AddWithValue("authorid", book.AuthorId);
        cmd.Parameters.AddWithValue("genreid", book.GenreId);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Added!");
    }

    public void DeleteBook(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "delete from books where id=@id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Deleted!");
    }

    public Book GetBook(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id, title, publishedyear, totalcopies, authorid, genreid from books where id=@id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        var data = cmd.ExecuteReader();
        var book = new Book();
        while (data.Read())
        {
            book.Id = data.GetInt32(0);
            book.Title = data.GetString(1);
            book.PublishedYear = data.GetInt32(2);
            book.TotalCopies = data.GetInt32(3);
            book.AuthorId = data.GetInt32(4);
            book.GenreId = data.GetInt32(5);
        }
        return book;
    }

    public List<Book> GetBooks()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id, title, publishedyear, totalcopies, authorid, genreid from books";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        var books = new List<Book>();
        while (data.Read())
        {
            var book = new Book();
            book.Id = data.GetInt32(0);
            book.Title = data.GetString(1);
            book.PublishedYear = data.GetInt32(2);
            book.TotalCopies = data.GetInt32(3);
            book.AuthorId = data.GetInt32(4);
            book.GenreId = data.GetInt32(5);
            books.Add(book);
        }
        return books;
    }

    public void UpdateBook(Book book)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "update books set title=@title, publishedyear=@publishedyear, totalcopies=@totalcopies, authorid=@authorid, genreid=@genreid where id=@id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("title", book.Title);
        cmd.Parameters.AddWithValue("publishedyear", book.PublishedYear);
        cmd.Parameters.AddWithValue("totalcopies", book.TotalCopies);
        cmd.Parameters.AddWithValue("authorid", book.AuthorId);
        cmd.Parameters.AddWithValue("genreid", book.GenreId);
        cmd.Parameters.AddWithValue("id", book.Id);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Updated!");
    }

    public List<Book> GetBooksByAuthor(string fullname)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = @"select b.id, b.title, b.publishedyear, b.totalcopies
        from books b
        join authors a on b.authorid = a.id
        where a.fullname = @fullname";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("fullname", fullname);
        var reader = cmd.ExecuteReader();
        List<Book> books = [];
        while (reader.Read())
        {
            var book = new Book();
            book.Id = reader.GetInt32(0);
            book.Title = reader.GetString(1);
            book.PublishedYear = reader.GetInt32(2);
            book.TotalCopies = reader.GetInt32(3);
            books.Add(book);
        }
        return books;
    }

    public List<Book> GetBooksByGenre(string name)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = @"select b.id, b.title, b.publishedyear, b.totalcopies
        from books b
        join genres g on b.genreid = g.id
        where g.name = @name";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("name", name);
        var reader = cmd.ExecuteReader();
        List<Book> books = [];
        while (reader.Read())
        {
            var book = new Book();
            book.Id = reader.GetInt32(0);
            book.Title = reader.GetString(1);
            book.PublishedYear = reader.GetInt32(2);
            book.TotalCopies = reader.GetInt32(3);
            books.Add(book);
        }
        return books;
    }
}