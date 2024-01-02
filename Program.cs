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
            var configuration = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");

            var databaseService = new DatabaseService(connectionString);
            var bookManager = new BookManager(databaseService);
            var shelfManager = new ShelfManager(databaseService);

            try
            {
                databaseService.CreateTables();


                Console.WriteLine("Application is running...");
                Console.WriteLine("Welcome to the Book and Shelf Management System!");

                while (true)
                {
                    Console.WriteLine("\nSelect an option:");
                    Console.WriteLine("1. Add a book");
                    Console.WriteLine("2. Delete a book");
                    Console.WriteLine("3. Add a Shelf");
                    Console.WriteLine("4. Add a book to shelf");
                    Console.WriteLine("5. View all books");
                    Console.WriteLine("6. View all books on shelves");
                    Console.WriteLine("7. View all shelves");
                    Console.WriteLine("8. Exit");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            bookManager.AddBook();
                            break;
                        case "2":
                            bookManager.DeleteBookByName();
                            break;
                        case "3":
                            shelfManager.AddShelf();
                            break;
                        case "4":
                            shelfManager.AddBookToShelf();
                            break;
                        case "5":
                            bookManager.ListAllBooks();
                            break;
                        case "6":
                            shelfManager.PrintShelvesWithBooks();  
                            break;
                        case "7":
                            shelfManager.ListAllShelves();
                            break;
                        case "8":
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
    }
}
