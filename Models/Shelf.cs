﻿using bukShelf.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyProject.Models
{
    public enum MaterialType
    {
        Wood,
        Metal
    }

    public class Shelf
    {
        public int Id { get; set; }
        public string ShelfType { get; set; }
        public double Surface { get; set; }
        public int BookCount { get; set; }
        public string Status { get; set; }
        public List<Book> Books { get; private set; }
        public double MaxWeightCapacity { get; private set; }
        public int MaxBooks { get; private set; }
        public double CurrentWeightLoad { get; set; }
        public bool IsShelfSafe { get; private set; }
        public MaterialType Material { get; private set; }

        public Shelf(string shelfType, double surface, MaterialType material)
        {
            ShelfType = shelfType;
            Surface = surface;
            Material = material;
            Books = new List<Book>();


            if (material == MaterialType.Wood)
            {
                MaxBooks = 6;
                MaxWeightCapacity = 10.14 * Surface;
            }
            else if (material == MaterialType.Metal)
            {
                MaxBooks = int.MaxValue;
                MaxWeightCapacity = 26.45 * Surface;
            }

            BookCount = 0;
            Status = "Safe";
        }
 
        private void UpdateShelfStatus()
        {
            double loadPercentage = (CurrentWeightLoad / MaxWeightCapacity) * 100;

            if (Material == MaterialType.Metal && loadPercentage > 125)
            {
                IsShelfSafe = false;
                Console.WriteLine($"Shelf {Id} is unsafe! Exceeds maximum load.");
            }
            else
            {
                IsShelfSafe = true;
                Console.WriteLine($"Shelf {Id} is safe. Load percentage: {loadPercentage}%");
            }
        }
        public bool AddBook(Book book)
        {
                Books.Add(book);
                BookCount++;
                CurrentWeightLoad += book.Weight;
                UpdateShelfStatus();
                return true;
            
        }
        public bool RemoveBook(Book book)
        {
            if (Books.Remove(book))
            {
                BookCount--;
                CurrentWeightLoad -= book.Weight;
                UpdateShelfStatus();
                return true;
            }
            else
            {
                Console.WriteLine($"Book '{book.Title}' is not on Shelf {Id}.");
                return false;
            }
        }
    }
}

