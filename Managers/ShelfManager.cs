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
            //Refers to Sci-Fi, Classic,...
            Console.WriteLine("Enter shelf type:");
            Console.Write("Shelf Type: ");
            string shelfType = Console.ReadLine();

            //Refers to surface area in cm^2
            Console.Write("Surface Area: ");
            double surfaceArea;
            double.TryParse(Console.ReadLine(), out surfaceArea);

            //Refers to type of material
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
            Console.WriteLine("Enter shelf ID to add a book: ");
            string shelfId = Console.ReadLine();

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

            // Add the book to the shelf in the database
            bool bookAddedToShelf = _databaseService.AddBookToShelf(shelfId, newBook);

            if (bookAddedToShelf)
            {
                Console.WriteLine("Book added to the shelf successfully!");
            }
            else
            {
                Console.WriteLine("Failed to add book to the shelf. Please check your input or shelf ID.");
            }
        }
    }
}