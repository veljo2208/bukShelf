using System;

namespace MyProject.Models
{
    public class Book
    {
 
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public double Weight { get; private set; }
        public double Size { get; private set; }

        public Book(string title, string author, double weight, double size)
        {
            Title = title;
            Author = author;
            Weight = weight;
            Size = size;
        }

        
        public void ChangeTitle(string newTitle)
        {
            Title = newTitle;
        }

        
        public void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        
        public void ChangeWeight(double newWeight)
        {
            Weight = newWeight;
        }

        
        public void ChangeSize(double newSize)
        {
            Size = newSize;
        }

        
        public override string ToString()
        {
            return $"{Title} by {Author} - Weight: {Weight}g, Size: {Size}cm²";
        }

        
        public void DisplayDetails()
        {
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Author: {Author}");
            Console.WriteLine($"Weight: {Weight}g");
            Console.WriteLine($"Size: {Size}cm²");
        }
    }
}
