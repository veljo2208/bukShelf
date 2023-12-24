using System;
using System.Collections.Generic;

namespace MyProject.Models
{
    public class Shelf
    {
        // Props
        public string ShelfId { get; private set; }
        public List<Book> Books { get; private set; }
        public double MaxShelfLoad { get; private set; }
        public double CurrentShelfLoad { get; private set; }
        public bool IsShelfSafe { get; private set; }

        // Constructor of shelf class
        public Shelf(string shelfId, double maxLoad)
        {
            ShelfId = shelfId;
            MaxShelfLoad = maxLoad;
            Books = new List<Book>();
            CurrentShelfLoad = 0;
            IsShelfSafe = true;
        }


        public void AddBook(Book book)
        {

            if (CurrentShelfLoad + book.Weight > MaxShelfLoad)
            {
                Console.WriteLine("Cannot add the book. Exceeds maximum load.");
                return;
            }

            Books.Add(book);
            CurrentShelfLoad += book.Weight;
            UpdateShelfStatus();
        }

        public void RemoveBook(Book book)
        {
            if (Books.Contains(book))
            {
                Books.Remove(book);
                CurrentShelfLoad -= book.Weight;
                UpdateShelfStatus();
            }
            else
            {
                Console.WriteLine("Book not found on this shelf.");
            }
        }

        private void UpdateShelfStatus()
        {
            double loadPercentage = (CurrentShelfLoad / MaxShelfLoad) * 100;

            if (loadPercentage > 100)
            {
                IsShelfSafe = false;
                Console.WriteLine($"Shelf {ShelfId} is unsafe! Exceeds maximum load.");
            }
            else
            {
                IsShelfSafe = true;
                Console.WriteLine($"Shelf {ShelfId} is safe. Load percentage: {loadPercentage}%");
            }
        }
    }
}

