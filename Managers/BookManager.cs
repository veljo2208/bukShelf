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

            bool addedSuccessfully = _databaseService.AddBookToDatabase(newBook);

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

            bool deletedSuccessfully = _databaseService.ReRemoveBookFromDatabase(bookName);

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

    }
}
