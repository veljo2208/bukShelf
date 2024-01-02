using bukShelf.Database;
using MyProject.Models;
using System;

namespace bukShelf.Managers
{
    public class BookManager
    {
        private readonly DatabaseService _databaseService;

        public BookManager(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void AddBook()
        {
            Console.WriteLine("Enter the shelf ID for the book: ");
            if (!int.TryParse(Console.ReadLine(), out int shelfId))
            {
                Console.WriteLine("Invalid input for shelf ID. Please enter a valid number.");
                return;
            }
            Console.WriteLine("Enter the book details:");
            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("Weight (grams): ");
            if (!double.TryParse(Console.ReadLine(), out double weight))
            {
                Console.WriteLine("Invalid input for weight. Please enter a valid number.");
                return;
            }

            Console.Write("Size (square centimeters): ");
            if (!double.TryParse(Console.ReadLine(), out double size))
            {
                Console.WriteLine("Invalid input for size. Please enter a valid number.");
                return;
            }

            Book newBook = new Book(title, author, weight, size);

            int generatedBookId = _databaseService.AddBookToDatabaseAndGetId(newBook, shelfId);

            bool addedSuccessfully = generatedBookId > 0;

            if (addedSuccessfully)
            {
                Console.WriteLine("Book added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add book.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public void DeleteBookByName()
        {
            Console.WriteLine("Enter the name of the book to delete: ");
            string bookName = Console.ReadLine();

            bool deletedSuccessfully = _databaseService.RemoveBookFromDatabase(bookName);

            if (deletedSuccessfully)
            {
                Console.WriteLine("Book deleted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to delete book.");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public void ListAllBooks()
        {
            List<Book> books = _databaseService.GetAllBooks();

            Console.WriteLine("Available Books:");
            Console.WriteLine("Id\tTitle\tAuthor");
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Id}\t{book.Title}\t{book.Author}");
            }
        }


    }
}
