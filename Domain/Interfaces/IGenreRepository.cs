using Domain.Models;

namespace Domain.Interfaces;

public interface IGenreRepositories
{
    Task AddGenreAsync(Genre genre);
    Task UpdateGenreAsync(Genre genre);
    Task DeleteGenreAsync(int id);
    Task<Genre> GetGenreAsync(int id);
    Task<List<Genre>> GetGenresAsync();
    Task<int> GetGenresAmountAsync();
}