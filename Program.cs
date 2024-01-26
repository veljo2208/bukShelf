using bukShelf.Database;
using bukShelf.Managers;
using Microsoft.Extensions.Configuration;
using System;

namespace bukShelf
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Book and Shelf Management System!");

            Console.WriteLine("\nChoose mode:");
            Console.WriteLine("1. Demo Mode");
            Console.WriteLine("2. Production Mode");

            string modeChoice = Console.ReadLine();

            bool isDemoMode = modeChoice == "1";

            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            var databaseService = new DatabaseService(connectionString);
            var bookManager = new BookManager(databaseService);
            var shelfManager = new ShelfManager(databaseService);

            databaseService.CreateTables();

            if (isDemoMode)
            {
                databaseService.InsertTestDataIntoShelfTable();
                databaseService.InsertTestDataIntoBookTable();
            }

            try
            {
                

                Console.WriteLine("Application is running...");

                while (true)
                {
                    Console.WriteLine("\nSelect an option:");
                    Console.WriteLine("1. Add a Shelf");
                    Console.WriteLine("2. Add a book to shelf");
                    Console.WriteLine("3. View all books");
                    Console.WriteLine("4. View all books on shelves");
                    Console.WriteLine("5. View all shelves");
                    Console.WriteLine("6. Delete a book");
                    Console.WriteLine("7. Exit");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            shelfManager.AddShelf();
                            break;
                        case "2":
                            shelfManager.PrintAvailableShelfGenres();
                            shelfManager.AddBookToShelf();
                            break;
                        case "3":
                            bookManager.ListAllBooks();
                            break;
                        case "4":
                            shelfManager.PrintShelvesWithBooks();
                            break;
                        case "5":
                            shelfManager.ListAllShelves();
                            break;
                        case "6":
                            bookManager.DeleteBookByName();
                            break;
                        case "7":
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please select valid option.");
                            break;
                    }
                }
            }
            finally
            {
                databaseService.DropTables();
            }
        }
    }
}
