using System.Data;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.DataSetRepositories;

public class AuthorRepository
{
    public void ShowAll()
    {
        using var connection = Database.Connection();
        var sql = "select * from authors";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        DataTable authorsTable = ds.Tables[0];

        foreach(DataRow dr in authorsTable.Rows)
        {
            System.Console.WriteLine(dr["id"]+" "+dr["fullname"]+" "+dr["country"]+" "+dr["birthyear"]);
        }
    }

    public void AddAuthor(Author author)
    {
        using var connection = Database.Connection();
        var sql = "select * from authors";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        var builder = new NpgsqlCommandBuilder(adapter);

        DataTable authorsTable = ds.Tables[0];

        DataRow row = authorsTable.NewRow();
        row["fullname"] = author.Fullname;
        row["country"] = author.Country;
        row["birthyear"] = author.BirthYear;
        authorsTable.Rows.Add(row);
        adapter.Update(ds);
    }

    public void UpdateAuthor(Author author)
    {
        using var connection = Database.Connection();
        var sql = "select * from authors";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        var builder = new NpgsqlCommandBuilder(adapter);

        DataTable authorsTable = ds.Tables[0];

        foreach(DataRow dataRow in authorsTable.Rows)
        {
            if (Convert.ToInt32(dataRow["id"]) == author.Id)
            {
                dataRow["fullname"]=author.Fullname;
                dataRow["country"]=author.Country;
                dataRow["birthyear"]=author.BirthYear;
                adapter.Update(ds);
                break;
            }
        }
    }

    public void DeleteAuthor(int id)
    {
        using var connection = Database.Connection();
        var sql = "select * from authors";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        var builder = new NpgsqlCommandBuilder(adapter);

        DataTable authorsTable = ds.Tables[0];

        foreach(DataRow dataRow in authorsTable.Rows)
        {
            if (Convert.ToInt32(dataRow["id"]) == id)
            {
                dataRow.Delete();
                adapter.Update(ds);
                break;
            }
        }
    }
}