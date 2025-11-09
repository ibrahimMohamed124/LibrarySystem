using LibrarySystem.Model;
using System.Collections.Generic;

namespace LibrarySystem.GetData
{
    public class GetBooksData
    {
        public static List<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book("The Alchemist", "Paulo Coelho", 45),
                new Book("Clean Code", "Robert C. Martin", 75),
                new Book("C# in Depth", "Jon Skeet", 60),
                new Book("The Pragmatic Programmer", "Andrew Hunt", 55),
                new Book("Design Patterns", "Erich Gamma", 80),
                new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 35),
                new Book("The Hobbit", "J.R.R. Tolkien", 50),
                new Book("Effective C#", "Bill Wagner", 65),
                new Book("Head First Design Patterns", "Eric Freeman", 70),
                new Book("The Lord of the Rings", "J.R.R. Tolkien", 90)
            };
        }
    }
}
