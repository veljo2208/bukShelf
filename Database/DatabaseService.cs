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

                        cmd.CommandText = "DROP TABLE IF EXISTS book, shelf";
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
    }
}

