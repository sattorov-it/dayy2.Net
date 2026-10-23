using Domain.Models;
using Infrastructure.DataSetRepositories;

var bookRepo = new BookRepository();
var authorRepo = new AuthorRepository();
var genreRepo = new GenreRepository();

while (true)
{
    System.Console.WriteLine("======================================");
    System.Console.WriteLine(@"1. Show all books.
2. Add new book.
3. Update book.
4. Delete book.
5. Show all authors.
6. Add new author.
7. Update author.
8. Delete author.
9. Show all genres.
10. Add new genre.
11. Update genre.
12. Delete genre.
13. Show books by author name.
14. Show books by genre name.
0. Exit.");
    var a = Console.ReadLine();
    System.Console.WriteLine("======================================");
    switch (a)
    {
        case "1":
            bookRepo.ShowAll();
            break;
        case "2":
            System.Console.Write("Enter title: ");
            var t = Console.ReadLine()!;
            System.Console.Write("Enter published year: ");
            var py = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter total copies: ");
            var tc = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter author id: ");
            var authorId = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter genre id: ");
            var genreId = Convert.ToInt32(Console.ReadLine());
            var newBook = new Book()
            {
                Title = t,
                PublishedYear = py,
                TotalCopies = tc,
                AuthorId = authorId,
                GenreId = genreId
            };
            bookRepo.AddBook(newBook);
            break;
        case "3":
            System.Console.Write("Enter id: ");
            var uid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter title: ");
            var ut = Console.ReadLine()!;
            System.Console.Write("Enter published year: ");
            var upy = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter total copies: ");
            var utc = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter author id: ");
            var uAuthorId = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter genre id: ");
            var uGenreId = Convert.ToInt32(Console.ReadLine());
            var updBook = new Book()
            {
                Id = uid,
                Title = ut,
                PublishedYear = upy,
                TotalCopies = utc,
                AuthorId = uAuthorId,
                GenreId = uGenreId
            };
            bookRepo.UpdateBook(updBook);
            break;
        case "4":
            System.Console.Write("Enter id: ");
            var did = Convert.ToInt32(Console.ReadLine());
            bookRepo.DeleteBook(did);
            break;
        case "5":
            authorRepo.ShowAll();
            break;
        case "6":
            System.Console.Write("Enter full name: ");
            var fn = Console.ReadLine()!;
            System.Console.Write("Enter country: ");
            var c = Console.ReadLine()!;
            System.Console.Write("Enter birth year: ");
            var by = Convert.ToInt32(Console.ReadLine());
            var newAuthor = new Author()
            {
                Fullname = fn,
                Country = c,
                BirthYear = by
            };
            authorRepo.AddAuthor(newAuthor);
            break;
        case "7":
            System.Console.Write("Enter id: ");
            var uaid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter full name: ");
            var ufn = Console.ReadLine()!;
            System.Console.Write("Enter country: ");
            var uc = Console.ReadLine()!;
            System.Console.Write("Enter birth year: ");
            var uby = Convert.ToInt32(Console.ReadLine());
            var updAuthor = new Author()
            {
                Id = uaid,
                Fullname = ufn,
                Country = uc,
                BirthYear = uby
            };
            authorRepo.UpdateAuthor(updAuthor);
            break;
        case "8":
            System.Console.Write("Enter id: ");
            var daid = Convert.ToInt32(Console.ReadLine());
            authorRepo.DeleteAuthor(daid);
            break;
        case "9":
            genreRepo.ShowAll();
            break;
        case "10":
            System.Console.Write("Enter genre name: ");
            var gn = Console.ReadLine()!;
            var newGenre = new Genre()
            {
                Name = gn
            };
            genreRepo.AddGenre(newGenre);
            break;
        case "11":
            System.Console.Write("Enter id: ");
            var ugid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter genre name: ");
            var ugn = Console.ReadLine()!;
            var updGenre = new Genre()
            {
                Id = ugid,
                Name = ugn
            };
            genreRepo.UpdateGenre(updGenre);
            break;
        case "12":
            System.Console.Write("Enter id: ");
            var dgid = Convert.ToInt32(Console.ReadLine());
            genreRepo.DeleteGenre(dgid);
            break;
        case "13":
            System.Console.Write("Enter author full name: ");
            var authorName = Console.ReadLine()!;
            var authorBooks = bookRepo.GetBooksByAuthor(authorName);
            foreach (var ab in authorBooks)
            {
                System.Console.WriteLine(ab.Id + " " + ab.Title + " " + ab.PublishedYear + " " + ab.TotalCopies);
            }
            break;
        case "14":
            System.Console.Write("Enter genre name: ");
            var genreName = Console.ReadLine()!;
            var genreBooks = bookRepo.GetBooksByGenre(genreName);
            foreach (var gb in genreBooks)
            {
                System.Console.WriteLine(gb.Id + " " + gb.Title + " " + gb.PublishedYear + " " + gb.TotalCopies);
            }
            break;
        case "0":
            System.Console.WriteLine("Exiting ...");
            return;
    }
}