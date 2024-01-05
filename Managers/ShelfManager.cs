using bukShelf.Database;
using bukShelf.Managers;
using MyProject.Models;
using System;

namespace bukShelf
{
    public class ShelfManager
    {
        private readonly DatabaseService _databaseService;

        public ShelfManager(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public void AddShelf()
        {
            Console.WriteLine("Enter shelf type:");
            Console.Write("Shelf Type: ");
            string shelfType = Console.ReadLine();

            Console.Write("Surface Area: ");
            double surfaceArea;
            double.TryParse(Console.ReadLine(), out surfaceArea);

            Console.WriteLine("Choose Material (Wood/Metal): ");
            MaterialType material;
            Enum.TryParse(Console.ReadLine(), out material);

            Shelf newShelf = new Shelf(shelfType, surfaceArea, material);

            bool shelfAdded = _databaseService.AddShelfToDatabase(newShelf);

            if (shelfAdded)
            {
                Console.WriteLine("Shelf added successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add shelf. Please check your input.");
            }
        }

        public void AddBookToShelf()
        {
            Console.WriteLine("Enter shelf genre to add a book: ");
            string shelfGenre = Console.ReadLine();

            int shelfId = _databaseService.GetShelfIdByGenre(shelfGenre);

            if (shelfId == -1)
            {
                Console.WriteLine($"There's no shelf with the genre: {shelfGenre}");
                return;
            }

            Console.WriteLine("Enter book details:");
            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.Write("Author: ");
            string author = Console.ReadLine();

            Console.Write("Weight: ");
            double weight;
            double.TryParse(Console.ReadLine(), out weight);

            Console.Write("Size: ");
            double size;
            double.TryParse(Console.ReadLine(), out size);

            Book newBook = new Book(title, author, weight, size);

            int generatedBookId = _databaseService.AddBookToDatabaseAndGetId(newBook, shelfId);

            if (generatedBookId > 0)
            {
                Console.WriteLine("Book added to the shelf successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add book to the shelf. Please check your input or shelf ID.");
            }
        }
        public void PrintAvailableShelfGenres()
        {
            List<string> availableGenres = _databaseService.GetAvailableShelfGenres();

            Console.WriteLine("Available shelf genres:");
            foreach (var genre in availableGenres)
            {
                Console.WriteLine($"- {genre}");
            }
        }
        public void ListAllShelves()
        {
            List<Shelf> shelves = _databaseService.GetAllShelves();

            Console.WriteLine("Available Shelves:");
            Console.WriteLine("Id\tType\tSurface[cm²]\t\tMaterial\tCount\tWeight[g]\tStatus");

            foreach (var shelf in shelves)
            {
                Console.WriteLine($"{shelf.Id}\t{shelf.ShelfType}\t{shelf.Surface,-16}\t{shelf.Material,-8}\t{shelf.BookCount}\t{shelf.CurrentWeightLoad,-10}\t{shelf.Status}");
            }
        }
        public void PrintShelvesWithBooks()
        {
            var shelfBooks = _databaseService.GetShelfBooks();

            foreach (var shelfType in shelfBooks.Keys)
            {
                Console.WriteLine($"---> Shelf Genre: {shelfType} <---");

                Console.WriteLine("Title\tAuthor\tWeight\tSize");

                foreach (var book in shelfBooks[shelfType])
                {
                    Console.WriteLine($"-{book.Title,5}\t{book.Author,2}\t{book.Weight}g\t{book.Size}cm²");
                }

                Console.WriteLine("----------------------------");
            }
        }
    }
}