using Domain.Models;
using Infrastructure.Repositories;

var repo = new BookRepository();
var authorRepo = new AuthorRepository();

while (true)
{
    System.Console.WriteLine("======================================");
    System.Console.WriteLine(@"1. Show all books.
2. Show book by id.
3. Add new book.
4. Update book.
5. Delete book.
6. Show all authors.
7. Show author by id.
8. Add new author.
9. Update author.
10. Delete author.
0. Exit.");
    var a = Console.ReadLine();
    System.Console.WriteLine("======================================");
    switch (a)
    {
        case "1":
            var books = repo.GetBooks();
            foreach (var b in books)
            {
                System.Console.WriteLine(b.Id + " " + b.Title + " " + b.PublishedYear + " " + b.TotalCopies);
            }
            break;
        case "2":
            System.Console.Write("Enter id: ");
            var id = Convert.ToInt32(Console.ReadLine());
            var bb = repo.GetBook(id);
            System.Console.WriteLine(bb.Id + " " + bb.Title + " " + bb.PublishedYear + " " + bb.TotalCopies);
            break;
        case "3":
            System.Console.Write("Enter title: ");
            var t = Console.ReadLine()!;
            System.Console.Write("Enter published year: ");
            var py = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter total copies: ");
            var tc = Convert.ToInt32(Console.ReadLine());
            var bbb = new Book()
            {
                Title = t,
                PublishedYear = py,
                TotalCopies = tc
            };
            repo.AddBook(bbb);
            break;
        case "4":
            System.Console.Write("Enter id: ");
            var uid = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter title: ");
            var ut = Console.ReadLine()!;
            System.Console.Write("Enter published year: ");
            var upy = Convert.ToInt32(Console.ReadLine());
            System.Console.Write("Enter total copies: ");
            var utc = Convert.ToInt32(Console.ReadLine());
            var ubbb = new Book()
            {
                Id = uid,
                Title = ut,
                PublishedYear = upy,
                TotalCopies = utc
            };
            repo.UpdateBook(ubbb);
            break;
        case "5":
            System.Console.Write("Enter id: ");
            var did = Convert.ToInt32(Console.ReadLine());
            repo.DeleteBook(did);
            break;
        case "6":
            var authors = authorRepo.GetAuthors();
            foreach (var au in authors)
            {
                System.Console.WriteLine(au.Id + " " + au.Fullname + " " + au.Country + " " + au.BirthYear);
            }
            break;
        case "7":
            System.Console.Write("Enter id: ");
            var aid = Convert.ToInt32(Console.ReadLine());
            var author = authorRepo.GetAuthor(aid);
            System.Console.WriteLine(author.Id + " " + author.Fullname + " " + author.Country + " " + author.BirthYear);
            break;
        case "8":
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
        case "9":
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
        case "10":
            System.Console.Write("Enter id: ");
            var daid = Convert.ToInt32(Console.ReadLine());
            authorRepo.DeleteAuthor(daid);
            break;
            
        case "0":
            System.Console.WriteLine("Exiting ...");
            return;

    }
}