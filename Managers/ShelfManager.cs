﻿using bukShelf.Database;
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
            Console.WriteLine("Enter shelf ID to add a book: ");
            if (int.TryParse(Console.ReadLine(), out int shelfId))
            {
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
        }

    }
}