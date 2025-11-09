using LibrarySystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.Extensions
{
    public class Filter
    {
        public static void AddBook(List<Book> books)
        {
            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            Console.Write("Enter Price: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                books.Add(new Book(title, author, price));
                Console.WriteLine("✅ Book added successfully!");
            }
            else
                Console.WriteLine("❌ Invalid price input.");
        }

        public static void RemoveBook(List<Book> books)
        {
            Console.Write("Enter Title to remove: ");
            string title = Console.ReadLine();

            var bookToRemove = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine("✅ Book removed successfully!");
            }
            else
                Console.WriteLine("❌ Book not found!");
        }

        public static void ViewAllBooks(List<Book> books)
        {
            Console.WriteLine("\n📚 All Books:");
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            books.ForEach(b => Console.WriteLine(b));
        }

        public static void GetBookByTitle(List<Book> books, string search)
        {
            var results = books.Where(b => b.Title.Contains(search, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\n🔍 Books matching title '{search}':");
            if (!results.Any())
                Console.WriteLine("No books found.");
            else
                foreach (var b in results)
                    Console.WriteLine(b);
        }

        public static void GetBookByAuthor(List<Book> books, string search)
        {
            var results = books.Where(b => b.Author.Contains(search, StringComparison.OrdinalIgnoreCase));

            Console.WriteLine($"\n👤 Books by author '{search}':");
            if (!results.Any())
                Console.WriteLine("No books found.");
            else
                foreach (var b in results)
                    Console.WriteLine(b);
        }

        public static void GetExpensiveBooks(List<Book> books)
        {
            var results = books.Where(b => b.Price > 50).OrderBy(b => b.Price);

            Console.WriteLine("\n💰 Expensive Books (>50):");
            if (!results.Any())
                Console.WriteLine("No expensive books found.");
            else
                foreach (var b in results)
                    Console.WriteLine(b);
        }

        public static void CountBooksByAuthor(List<Book> books)
        {
            var result = books.GroupBy(b => b.Author)
                              .Select(g => new { Author = g.Key, Count = g.Count() });

            Console.WriteLine("\n📊 Books Count by Author:");
            foreach (var item in result)
                Console.WriteLine($"{item.Author}: {item.Count}");
        }

        public static void EditBook(List<Book> books)
        {
            Console.Write("Enter Title of the book to edit: ");
            string title = Console.ReadLine();

            var bookToEdit = books.FirstOrDefault(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (bookToEdit == null)
            {
                Console.WriteLine("❌ Book not found!");
                return;
            }

            Console.WriteLine($"\nEditing: {bookToEdit.Title} by {bookToEdit.Author}, Price: ${bookToEdit.Price}");

            Console.Write("Enter new Title (or press Enter to keep the same): ");
            string newTitle = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newTitle))
                bookToEdit.Title = newTitle;

            Console.Write("Enter new Author (or press Enter to keep the same): ");
            string newAuthor = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAuthor))
                bookToEdit.Author = newAuthor;

            Console.Write("Enter new Price (or press Enter to keep the same): ");
            string newPriceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPriceInput))
            {
                if (decimal.TryParse(newPriceInput, out decimal newPrice))
                    bookToEdit.Price = newPrice;
                else
                    Console.WriteLine("❌ Invalid price, keeping old value.");
            }

            Console.WriteLine("✅ Book details updated successfully!");
        }
    }
}
