using System.Data;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.DataSetRepositories;

public class GenreRepository
{
    public void ShowAll()
    {
        using var connection = Database.Connection();
        var sql = "select * from genres";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        DataTable genresTable = ds.Tables[0];

        foreach (DataRow dr in genresTable.Rows)
        {
            System.Console.WriteLine(dr[0] + " " + dr[1]);
        }
    }

    public void AddGenre(Genre genre)
    {
        using var connection = Database.Connection();
        var sql = "select * from genres";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        var builder = new NpgsqlCommandBuilder(adapter);

        DataTable genresTable = ds.Tables[0];

        DataRow row = genresTable.NewRow();
        row["name"] = genre.Name;
        genresTable.Rows.Add(row);
        adapter.Update(ds);
    }

    public void UpdateGenre(Genre genre)
    {
        using var connection = Database.Connection();
        var sql = "select * from genres";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        var builder = new NpgsqlCommandBuilder(adapter);

        DataTable genresTable = ds.Tables[0];

        foreach (DataRow dataRow in genresTable.Rows)
        {
            if (Convert.ToInt32(dataRow["id"]) == genre.Id)
            {
                dataRow["name"] = genre.Name;
                adapter.Update(ds);
                break;
            }
        }
    }

    public void DeleteGenre(int id)
    {
        using var connection = Database.Connection();
        var sql = "select * from genres";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        var builder = new NpgsqlCommandBuilder(adapter);

        DataTable genresTable = ds.Tables[0];

        foreach (DataRow dataRow in genresTable.Rows)
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