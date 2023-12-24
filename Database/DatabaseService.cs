using System;
using System.IO;
using MyProject.Models;
using Npgsql;

namespace bukShelf.Database
{
    public class DatabaseService
    {
        private readonly string connectionString;

        public DatabaseService(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateTables()
        {
            string bookScript = File.ReadAllText(@"D:\Projects\school-project\bukShelf\SqlScripts\CreateTableBook.sql");
            string shelfScript = File.ReadAllText(@"D:\Projects\school-project\bukShelf\SqlScripts\CreateTableShelf.sql");
            string shelfBookScript = File.ReadAllText(@"D:\Projects\school-project\bukShelf\SqlScripts\CreateTableShelfBook.sql");

            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected to PostgreSQL!");

                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = bookScript;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = shelfScript;
                        cmd.ExecuteNonQuery();

                        cmd.CommandText = shelfBookScript;
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        public void DropTables()
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected to PostgreSQL!");

                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;

                        cmd.CommandText = "DROP TABLE IF EXISTS book, shelf, shelfbook";
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        public bool AddBookToDatabase(Book newBook)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Book (Title, Author, Weight, Size) VALUES (@Title, @Author, @Weight, @Size)";
                    cmd.Parameters.AddWithValue("Title", newBook.Title);
                    cmd.Parameters.AddWithValue("Author", newBook.Author);
                    cmd.Parameters.AddWithValue("Weight", newBook.Weight);
                    cmd.Parameters.AddWithValue("Size", newBook.Size);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool RemoveBookFromDatabase(string bookName)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM Book WHERE Title = @Title";
                    cmd.Parameters.AddWithValue("Title", bookName);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT Id, Title, Author, Weight, Size FROM Book", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book book = new Book(
                                reader["Title"].ToString(),
                                reader["Author"].ToString(),
                                Convert.ToDouble(reader["Weight"]),
                                Convert.ToDouble(reader["Size"])
                            );
                            book.Id = Convert.ToInt32(reader["Id"]); 
                            books.Add(book);
                        }
                    }
                }
            }

            return books;
        }



        public bool AddShelfToDatabase(Shelf newShelf)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;  
                    cmd.CommandText = "INSERT INTO Shelf (Shelf_Type, Surface, Book_Count, Current_Weight_Load, Material, Shelf_Status) VALUES (@ShelfType, @Surface, @BookCount,@CurrentWeight,@Material, @Status)";
                    cmd.Parameters.AddWithValue("ShelfType", newShelf.ShelfType);
                    cmd.Parameters.AddWithValue("Surface", newShelf.Surface);
                    cmd.Parameters.AddWithValue("BookCount", newShelf.BookCount);
                    cmd.Parameters.AddWithValue("CurrentWeight", newShelf.CurrentWeightLoad);
                    cmd.Parameters.AddWithValue("Material", newShelf.Material.ToString());
                    cmd.Parameters.AddWithValue("Status", newShelf.Status);


                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool AddBookToShelf(string shelfId, Book newBook)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO ShelfBook (ShelfId, BookTitle) VALUES (@ShelfId, @BookTitle)";
                    cmd.Parameters.AddWithValue("ShelfId", shelfId);
                    cmd.Parameters.AddWithValue("BookTitle", newBook.Title);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}

