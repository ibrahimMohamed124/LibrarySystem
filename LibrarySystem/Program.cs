// See https://aka.ms/new-console-template for more information
using LibrarySystem.Model;
using LibrarySystem.Extensions;
using LibrarySystem.GetData;

class Program
{
    static void Main()
    {
        var books = GetBooksData.GetBooks();

        do
        {
            Console.WriteLine("\n===== Library System =====");
            List<string> choices = new List<string>
            {
                "1- Add Book",
                "2- Edit Book",
                "3- View All Books",
                "4- Search by Title",
                "5- Search by Author",
                "6- View Expensive Books (>50)",
                "7- Count Books by Author",
                "8- Remove Book",
                "0- Exit"
            };
            choices.ForEach(c => Console.WriteLine(c));

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Filter.AddBook(books);
                    break;
                case "2":
                    Filter.EditBook(books);
                    break;

                case "3":
                    Filter.ViewAllBooks(books);
                    break;
                case "4":
                    Console.Write("Enter title to search: ");
                    string searchTitle = Console.ReadLine();
                    Filter.GetBookByTitle(books, searchTitle);
                    break;

                case "5":
                    Console.Write("Enter author to search: ");
                    string searchAuthor = Console.ReadLine();
                    Filter.GetBookByAuthor(books, searchAuthor);
                    break;

                case "6":
                    Filter.GetExpensiveBooks(books);
                    break;

                case "7":
                    Filter.CountBooksByAuthor(books);
                    break;

                case "8":
                    Filter.RemoveBook(books);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

            Console.Write("\nDo you want to continue? (y/n): ");
            if (Console.ReadLine().ToLower() != "y")
                break;

        } while (true);
    }
}
