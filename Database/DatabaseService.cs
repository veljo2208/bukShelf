using System;
using System.IO;
using System.Reflection;
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

        public void InsertTestDataIntoShelfTable()
        {
            string sqlScript = @"
        INSERT INTO Shelf (Shelf_Type, Surface, Material, Book_Count, Current_Weight_Load, Shelf_Status)
        VALUES
            ('SciFi', 261.2709925, 'Wood', 0, 0, 'Safe'),
            ('Historical', 460.6790365, 'Metal', 0, 0, 'Safe'),
            ('Romance', 979.1627123, 'Wood', 0, 0, 'Safe'),
            ('Drama', 993.003325, 'Metal', 0, 0, 'Safe'),
            ('Philosophy', 928.3955926, 'Wood', 0, 0, 'Safe'),
            ('Psychology', 570.9293824, 'Metal', 0, 0, 'Safe'),
            ('Romance', 635.2762531, 'Wood', 0, 0, 'Safe'),
            ('Economy', 476.9784323, 'Metal', 0, 0, 'Safe'),
            ('Comic', 174.2419124, 'Wood', 0, 0, 'Safe'); ";
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connected to PostgreSQL!");

                    using (var cmd = new NpgsqlCommand(sqlScript, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Data inserted into Shelf table.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data into Shelf table: {ex.Message}");
            }
        }
        public void InsertTestDataIntoBookTable()
        {
            string sqlScript1 = @"
         INSERT INTO Book (Title, Author, Weight, Size)   
         VALUES
            ('LOTR','Tolkien','3000','123'),
            ('Philosopher''s Stone','J. K. Rowling','3000','123'), -- Escape the single quote
            ('Chamber of Secrets','J. K. Rowling','3000','123'),
            ('Prisoner of Azkaban','J. K. Rowling','3000','123'),
            ('Goblet of Fire','J. K. Rowling','3000','123'),
            ('Order of the Phoenix','J. K. Rowling','3000','123'),
            ('Half-Blood Prince','J. K. Rowling','3000','123'),
            ('Deathly Hallows','J. K. Rowling','3000','123') ";

            string sqlScript2 = @"
         INSERT INTO shelfbook (ShelfId, BookId)
         VALUES 
            (1,1),
            (1,2),
            (1,3),
            (1,4),
            (1,5),
            (1,6),
            (1,7),
            (1,8) ";
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connected to PostgreSQL!");

                    using (var cmd = new NpgsqlCommand(sqlScript1, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Data inserted into books table.");
                    }
                    using (var cmd = new NpgsqlCommand(sqlScript2, conn))
                    {
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Shelfs and books connected.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data into Shelf table: {ex.Message}");
            }
        }

        public void InsertDataFromCSVIntoBookTable(string filePath)
        {
            try
            {
                using (var conn = new NpgsqlConnection(connectionString))
                {
                    conn.Open();
                    Console.WriteLine("Connected to PostgreSQL!");

                    using (var cmd = new NpgsqlCommand())
                    {
                        cmd.Connection = conn;

                        using (var reader = new StreamReader(filePath))
                        {
                            while (!reader.EndOfStream)
                            {
                                var line = reader.ReadLine();
                                var values = line.Split(',');

                                cmd.CommandText = $"INSERT INTO Book (Title, Author, Weight, Size) " +
                                                  $"VALUES ('{values[0]}', '{values[1]}', {values[2]}, {values[3]})";

                                cmd.ExecuteNonQuery();
                            }
                        }

                        Console.WriteLine("Data inserted into Book table.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inserting data into Book table: {ex.Message}");
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
                        double bookWeight = GetBookWeightFromDatabase(generatedBookId);

                        if (!ReferenceBookToShelf(generatedBookId, shelfId))
                        {
                            return -1;
                        }

                        UpdateShelfWeight(shelfId, bookWeight);

                        return generatedBookId;
                    }
                    else
                    {
                        throw new InvalidOperationException("Failed to retrieve generated BookId after insertion.");
                    }
                }
            }
        }
        public double GetBookWeightFromDatabase(int bookId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Weight FROM Book WHERE Id = @BookId";
                    cmd.Parameters.AddWithValue("BookId", bookId);

                    var result = cmd.ExecuteScalar();
                    if (result != null && double.TryParse(result.ToString(), out double bookWeight))
                    {
                        return bookWeight;
                    }
                    else
                    {
                        throw new InvalidOperationException("Failed to retrieve book weight from the database.");
                    }
                }
            }
        }
        public void UpdateShelfWeight(int shelfId, double bookWeight)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Shelf SET Current_Weight_Load = Current_Weight_Load + @BookWeight WHERE Id = @ShelfId";
                    cmd.Parameters.AddWithValue("BookWeight", bookWeight);
                    cmd.Parameters.AddWithValue("ShelfId", shelfId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("Failed to update shelf weight.");
                    }
                }
            }
        }
        public bool UpdateShelfStatus(int shelfId, string status)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Shelf SET Shelf_Status = @Status WHERE Id = @ShelfId";
                    cmd.Parameters.AddWithValue("Status", status);
                    cmd.Parameters.AddWithValue("ShelfId", shelfId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public Shelf GetShelfById(int shelfId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT Id, Shelf_Type, Surface, Book_Count, Current_Weight_Load, Material FROM Shelf WHERE Id = @ShelfId", conn))
                {
                    cmd.Parameters.AddWithValue("ShelfId", shelfId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Shelf shelf = new Shelf(
                                reader["Shelf_Type"].ToString(),
                                Convert.ToDouble(reader["Surface"]),
                                (MaterialType)Enum.Parse(typeof(MaterialType), reader["Material"].ToString())
                            );

                            shelf.Id = Convert.ToInt32(reader["Id"]);
                            shelf.BookCount = Convert.ToInt32(reader["Book_Count"]);
                            shelf.CurrentWeightLoad = Convert.ToDouble(reader["Current_Weight_Load"]);

                            return shelf;
                        }
                        else
                        {
                            return null;
                        }
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
                using (var cmd = new NpgsqlCommand("SELECT Id, Shelf_Type, Surface, Book_Count, Current_Weight_Load, Material FROM Shelf ORDER BY Id", conn))
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
        public void IncrementBookCount(int shelfId)
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
        public Dictionary<string, List<Book>> GetShelfBooks()
        {
            Dictionary<string, List<Book>> shelfBooks = new Dictionary<string, List<Book>>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT Shelf.Shelf_Type, Book.Id, Book.Title, Book.Author, Book.Weight, Book.Size FROM Shelf " +
                                                  "INNER JOIN ShelfBook ON Shelf.Id = ShelfBook.ShelfId " +
                                                  "INNER JOIN Book ON ShelfBook.BookId = Book.Id", conn))
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
        public int GetBookCountForShelf(int shelfId)
        {
            int bookCount = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT COUNT(*) FROM ShelfBook WHERE ShelfId = @ShelfId", conn))
                {
                    cmd.Parameters.AddWithValue("ShelfId", shelfId);
                    object result = cmd.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int count))
                    {
                        bookCount = count;
                    }
                }
            }

            return bookCount;
        }
        public double GetCurrentWeightLoadForShelf(int shelfId)
        {
            double currentWeightLoad = 0;

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT SUM(Weight) FROM Book INNER JOIN ShelfBook ON Book.Id = ShelfBook.BookId WHERE ShelfId = @ShelfId", conn))
                {
                    cmd.Parameters.AddWithValue("ShelfId", shelfId);
                    object result = cmd.ExecuteScalar();

                    if (result != null && double.TryParse(result.ToString(), out double weightSum))
                    {
                        currentWeightLoad = weightSum;
                    }
                }
            }

            return currentWeightLoad;
        }
        public bool CanAddBookToShelf(int shelfId, Book newBook)
        {
            Shelf shelf = GetShelfById(shelfId);

            if (shelf == null)
            {
                Console.WriteLine($"Shelf with ID {shelfId} not found.");
                return false;
            }

            if (shelf.Material == MaterialType.Wood && shelf.BookCount >= 6)
            {
                Console.WriteLine($"Shelf with ID {shelfId} (Wood) is full. Cannot add more books.");
                return false;
            }

            if (shelf.CurrentWeightLoad + newBook.Weight > shelf.MaxWeightCapacity)
            {
                Console.WriteLine($"Shelf with ID {shelfId} exceeds weight capacity. Cannot add the book.");
                return false;
            }

            return true;
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


