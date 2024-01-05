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
            string bookScript = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SqlScripts", "CreateTableBook.sql"));
            string shelfScript = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SqlScripts", "CreateTableShelf.sql"));
            string shelfBookScript = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "SqlScripts", "CreateTableShelfBook.sql"));

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
        public int AddBookToDatabaseAndGetId(Book newBook, int shelfId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO Book (Title, Author, Weight, Size) VALUES (@Title, @Author, @Weight, @Size) RETURNING Id";
                    cmd.Parameters.AddWithValue("Title", newBook.Title);
                    cmd.Parameters.AddWithValue("Author", newBook.Author);
                    cmd.Parameters.AddWithValue("Weight", newBook.Weight);
                    cmd.Parameters.AddWithValue("Size", newBook.Size);

                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int generatedBookId))
                    {
                        if (!ReferenceBookToShelf(generatedBookId, shelfId))
                        {
                            return -1;
                        }
                        return generatedBookId;
                    }
                    else
                    {
                        throw new InvalidOperationException("Failed to retrieve generated BookId after insertion.");
                    }
                }
            }
        }
        public bool ReferenceBookToShelf(int bookId, int shelfId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO ShelfBook (ShelfId, BookId) VALUES (@ShelfId, @BookId)";
                    cmd.Parameters.AddWithValue("ShelfId", shelfId);
                    cmd.Parameters.AddWithValue("BookId", bookId);

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

        public List<Shelf> GetAllShelves()
        {
            List<Shelf> shelves = new List<Shelf>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT Id, Shelf_Type, Surface, Book_Count, Current_Weight_Load, Material FROM Shelf", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Shelf shelf = new Shelf(
                                reader["Shelf_Type"].ToString(),
                                Convert.ToDouble(reader["Surface"]),
                                (MaterialType)Enum.Parse(typeof(MaterialType), reader["Material"].ToString())
                            );

                            shelf.Id = Convert.ToInt32(reader["Id"]);
                            shelf.BookCount = Convert.ToInt32(reader["Book_Count"]);
                            shelf.CurrentWeightLoad = Convert.ToDouble(reader["Current_Weight_Load"]);

                            shelves.Add(shelf);
                        }
                    }
                }
            }

            return shelves;
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

        public bool AddBookToShelf(int shelfId, Book newBook)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "INSERT INTO ShelfBook (ShelfId, BookId) VALUES (@ShelfId, @BookId)";
                        cmd.Parameters.AddWithValue("ShelfId", shelfId);
                        cmd.Parameters.AddWithValue("BookId", newBook.Id);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        IncrementBookCount(shelfId);
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book to shelf: {ex.Message}");
                return false;
            }
        }
        private void IncrementBookCount(int shelfId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Shelf SET Book_Count = Book_Count + 1 WHERE Id = @ShelfId";
                    cmd.Parameters.AddWithValue("ShelfId", shelfId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public Dictionary<string, List<Book>> GetShelfBooks()
        {
            Dictionary<string, List<Book>> shelfBooks = new Dictionary<string, List<Book>>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT Shelf.Shelf_Type, Book.Id, Book.Title, Book.Author, Book.Weight, Book.Size FROM Shelf " +
                                                  "LEFT JOIN ShelfBook ON Shelf.Id = ShelfBook.ShelfId " +
                                                  "LEFT JOIN Book ON ShelfBook.BookId = Book.Id", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string shelfType = reader["Shelf_Type"].ToString();
                            string bookTitle = reader["Title"].ToString();
                            string bookAuthor = reader["Author"].ToString();

                            double bookWeight = 0.0;
                            if (!reader.IsDBNull(reader.GetOrdinal("Weight")))
                            {
                                bookWeight = Convert.ToDouble(reader["Weight"]);
                            }

                            double bookSize = 0.0;
                            if (!reader.IsDBNull(reader.GetOrdinal("Size")))
                            {
                                bookSize = Convert.ToDouble(reader["Size"]);
                            }

                            Book book = new Book(bookTitle, bookAuthor, bookWeight, bookSize);

                            if (!shelfBooks.ContainsKey(shelfType))
                            {
                                shelfBooks[shelfType] = new List<Book>();
                            }

                            shelfBooks[shelfType].Add(book);
                        }
                    }
                }
            }

            return shelfBooks;
        }
        public int GetShelfIdByGenre(string shelfGenre)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Id FROM Shelf WHERE Shelf_Type = @ShelfType";
                    cmd.Parameters.AddWithValue("ShelfType", shelfGenre);

                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int shelfId))
                    {
                        return shelfId;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }
        public List<string> GetAvailableShelfGenres()
        {
            List<string> availableGenres = new List<string>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT DISTINCT Shelf_Type FROM Shelf", conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            availableGenres.Add(reader["Shelf_Type"].ToString());
                        }
                    }
                }
            }
            return availableGenres;
        }
    }
}


