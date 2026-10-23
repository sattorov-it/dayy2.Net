using System.Data;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.DataSetRepositories;

public class BookRepository
{
    public void ShowAll()
    {
        using var connection = Database.Connection();
        var sql = "select * from books";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        DataTable booksTable = ds.Tables[0];

        foreach (DataRow dr in booksTable.Rows)
        {
            System.Console.WriteLine(dr["id"] + " " + dr["title"] + " " + dr["publishedyear"] + " " + dr["totalcopies"]);
        }
    }

    public void AddBook(Book book)
    {
        using var connection = Database.Connection();
        var sql = "select * from books";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        var builder = new NpgsqlCommandBuilder(adapter);

        DataTable booksTable = ds.Tables[0];

        DataRow row = booksTable.NewRow();
        row["title"] = book.Title;
        row["publishedyear"] = book.PublishedYear;
        row["totalcopies"] = book.TotalCopies;
        row["authorid"] = book.AuthorId;
        row["genreid"] = book.GenreId;
        booksTable.Rows.Add(row);
        adapter.Update(ds);
    }

    public void UpdateBook(Book book)
    {
        using var connection = Database.Connection();
        var sql = "select * from books";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        var builder = new NpgsqlCommandBuilder(adapter);

        DataTable booksTable = ds.Tables[0];

        foreach (DataRow dataRow in booksTable.Rows)
        {
            if (Convert.ToInt32(dataRow["id"]) == book.Id)
            {
                dataRow["title"] = book.Title;
                dataRow["publishedyear"] = book.PublishedYear;
                dataRow["totalcopies"] = book.TotalCopies;
                dataRow["authorid"] = book.AuthorId;
                dataRow["genreid"] = book.GenreId;
                adapter.Update(ds);
                break;
            }
        }
    }

    public void DeleteBook(int id)
    {
        using var connection = Database.Connection();
        var sql = "select * from books";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        var builder = new NpgsqlCommandBuilder(adapter);

        DataTable booksTable = ds.Tables[0];

        foreach (DataRow dataRow in booksTable.Rows)
        {
            if (Convert.ToInt32(dataRow["id"]) == id)
            {
                dataRow.Delete();
                adapter.Update(ds);
                break;
            }
        }
    }

    public List<Book> GetBooksByAuthor(string fullname)
    {
        using var connection = Database.Connection();
        var sql = @"select b.id, b.title, b.publishedyear, b.totalcopies
        from books b
        join authors a on b.authorid = a.id
        where a.fullname = @fullname";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        adapter.SelectCommand!.Parameters.AddWithValue("fullname", fullname);
        var ds = new DataSet();
        adapter.Fill(ds);

        DataTable booksTable = ds.Tables[0];

        var books = new List<Book>();
        foreach (DataRow dataRow in booksTable.Rows)
        {
            var book = new Book();
            book.Id = Convert.ToInt32(dataRow["id"]);
            book.Title = dataRow["title"].ToString()!;
            book.PublishedYear = Convert.ToInt32(dataRow["publishedyear"]);
            book.TotalCopies = Convert.ToInt32(dataRow["totalcopies"]);
            books.Add(book);
        }
        return books;
    }

    public List<Book> GetBooksByGenre(string name)
    {
        using var connection = Database.Connection();
        var sql = @"select b.id, b.title, b.publishedyear, b.totalcopies
        from books b
        join genres g on b.genreid = g.id
        where g.name = @name";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        adapter.SelectCommand!.Parameters.AddWithValue("name", name);
        var ds = new DataSet();
        adapter.Fill(ds);

        DataTable booksTable = ds.Tables[0];

        var books = new List<Book>();
        foreach (DataRow dataRow in booksTable.Rows)
        {
            var book = new Book();
            book.Id = Convert.ToInt32(dataRow["id"]);
            book.Title = dataRow["title"].ToString()!;
            book.PublishedYear = Convert.ToInt32(dataRow["publishedyear"]);
            book.TotalCopies = Convert.ToInt32(dataRow["totalcopies"]);
            books.Add(book);
        }
        return books;
    }
}