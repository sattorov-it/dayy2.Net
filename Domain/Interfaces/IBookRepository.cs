using Domain.Models;
namespace Domain.Interfaces;

public interface IBookRepositories
{
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(int id);
    Task<Book> GetBookAsync(int id);
    Task<List<Book>> GetBooksAsync();
    Task<int> GetBookAmountAsync();
    Task<int> GetMinPublishedYearByAuthorAsync(int authorId);
    Task<int> GetMaxPublishedYearByAuthorAsync(int authorId);
    Task<int> GetMinPublishedYearByGenreAsync(int genreId);
    Task<int> GetMaxPublishedYearByGenreAsync(int genreId);
    Task<int> GetAmountByPublishedYearAsync(int year);
    Task<int> GetAmountByGenreAsync(int genreId);
}