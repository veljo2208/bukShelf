using bukShelf.Database;
using MyProject.Models;

namespace bukShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Host=localhost;Port=5432;Database=bukShelfDatabase;Username=admin;Password=admin";

            var databaseService = new DatabaseService(connectionString);

            try
            {
                databaseService.CreateTables();

                Console.WriteLine("Application is running...");
                Console.WriteLine("Welcome to the Book Management System!");

                while (true)
                {
                    Console.WriteLine("Inside the loop."); 
                    Console.WriteLine("\nSelect an option:");
                    Console.WriteLine("1. Add a Book");
                    Console.WriteLine("2. Exit");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddBook(databaseService); // Pass the database service instance
                            break;
                        case "2":
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
            finally
            {
                databaseService.DropTables();
            }
        }

        static void AddBook(DatabaseService databaseService)
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

            bool addedSuccessfully = databaseService.AddBookToDatabase(newBook);

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
    }
}
