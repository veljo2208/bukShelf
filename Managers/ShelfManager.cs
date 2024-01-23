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

            Shelf selectedShelf = _databaseService.GetShelfById(shelfId);

            if (selectedShelf.BookCount < selectedShelf.MaxBooks && (selectedShelf.CurrentWeightLoad + newBook.Weight) <= selectedShelf.MaxWeightCapacity)
            {
                int generatedBookId = _databaseService.AddBookToDatabaseAndGetId(newBook, shelfId);

                if (generatedBookId > 0)
                {
                    Console.WriteLine("Book added to the shelf successfully!");
                    _databaseService.IncrementBookCount(shelfId);

                    
                    double updatedWeightLoad = selectedShelf.CurrentWeightLoad + newBook.Weight;
                    _databaseService.UpdateShelfWeight(shelfId, updatedWeightLoad - newBook.Weight);

                    string shelfStatus = updatedWeightLoad > selectedShelf.MaxWeightCapacity ? "Unsafe" : "Safe";
                    _databaseService.UpdateShelfStatus(shelfId, shelfStatus);
                }
                else
                {
                    Console.WriteLine("Failed to add book to the shelf. Please check your input or shelf ID.");
                }
            }
            else
            {
                Console.WriteLine("The book cannot be added to the shelf due to capacity limitations.");
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
            Console.WriteLine("Id\tType\t\tSurface[cm²]\tMaterial\tCount\tWeight[g]\tStatus");

            foreach (var shelf in shelves)
            {
                Console.WriteLine($"{shelf.Id}\t{shelf.ShelfType,-12}\t{shelf.Surface,-14:F2}\t{shelf.Material,-8}\t{shelf.BookCount}\t{shelf.CurrentWeightLoad,-10}\t{shelf.Status}");
            }
        }
        private bool CanAddBookToWoodShelf(int shelfId, Book book)
        {
            Shelf shelf = _databaseService.GetShelfById(shelfId);

            if (shelf != null && shelf.Material == MaterialType.Wood && shelf.BookCount >= 6)
            {
                Console.WriteLine($"Shelf with ID {shelfId} (Wood) is full. Cannot add more books.");
                return false;
            }

            return true;
        }
        private string CalculateShelfStatus(Shelf shelf)
        {
            if (shelf.Material == MaterialType.Wood)
            {
                // Hard-code treba izbaciti 
                double maxWeightCapacity = shelf.Surface * 10.14;
                if (shelf.CurrentWeightLoad <= maxWeightCapacity)
                {
                    return "Safe";
                }
            }
            else if (shelf.Material == MaterialType.Metal)
            {
                double maxWeightCapacity = shelf.Surface * 26.45; 
                double threshold = maxWeightCapacity * 1.25; 
                if (shelf.CurrentWeightLoad <= threshold)
                {
                    return "Safe";
                }
            }
            return "Unsafe";
        }
        public void PrintShelvesWithBooks()
        {
            var shelfBooks = _databaseService.GetShelfBooks();

            foreach (var shelfType in shelfBooks.Keys)
            {
                if (shelfBooks[shelfType].Count > 0)
                {
                    Console.WriteLine($"-> Shelf Genre: {shelfType} <-");

                    Console.WriteLine("Id\tTitle\t\tAuthor\t\tWeight(g)\tSize(cm²)");
                    Console.WriteLine("---------------------------------------------------------------------------------------------");

                    int id = 1;
                    foreach (var book in shelfBooks[shelfType])
                    {
                        Console.WriteLine($"{id}\t{book.Title,-15}\t{book.Author,-15}\t{book.Weight,-15}g\t{book.Size,-15}cm²");
                        id++;
                    }
                }
            }
        }
    }
}