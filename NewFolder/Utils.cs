
//using MyProject.Models;
//using System;
//using System.Collections.Generic;
//using ClosedXML;

//public class Utils
//{
//    public static void ExportToExcel(List<Shelf> shelves, List<Book> books)
//    {
//        var workbook = new XLWorkbook();
//        var shelfWorksheet = workbook.Worksheets.Add("Shelves");
//        var bookWorksheet = workbook.Worksheets.Add("Books");

        
//        shelfWorksheet.Cell(1, 1).Value = "Shelf ID";
//        shelfWorksheet.Cell(1, 2).Value = "Shelf Type";
//        shelfWorksheet.Cell(1, 3).Value = "Surface [cm²]";
//        shelfWorksheet.Cell(1, 4).Value = "Material";
//        shelfWorksheet.Cell(1, 5).Value = "Count";
//        shelfWorksheet.Cell(1, 6).Value = "Weight [g]";
//        shelfWorksheet.Cell(1, 7).Value = "Status";

//        int shelfRow = 2;
//        foreach (var shelf in shelves)
//        {
//            shelfWorksheet.Cell(shelfRow, 1).Value = shelf.Id;
//            shelfWorksheet.Cell(shelfRow, 2).Value = shelf.ShelfType;
//            shelfWorksheet.Cell(shelfRow, 3).Value = shelf.Surface;
//            shelfWorksheet.Cell(shelfRow, 4).Value = shelf.Material;
//            shelfWorksheet.Cell(shelfRow, 5).Value = shelf.BookCount;
//            shelfWorksheet.Cell(shelfRow, 6).Value = shelf.CurrentWeightLoad;
//            shelfWorksheet.Cell(shelfRow, 7).Value = shelf.Status;
//            shelfRow++;
//        }


//        bookWorksheet.Cell(1, 1).Value = "Book ID";
//        bookWorksheet.Cell(1, 2).Value = "Title";
//        bookWorksheet.Cell(1, 3).Value = "Author";
//        bookWorksheet.Cell(1, 4).Value = "Weight [g]";
//        bookWorksheet.Cell(1, 5).Value = "Size [cm²]";

//        int bookRow = 2;
//        foreach (var book in books)
//        {
//            bookWorksheet.Cell(bookRow, 1).Value = book.Id;
//            bookWorksheet.Cell(bookRow, 2).Value = book.Title;
//            bookWorksheet.Cell(bookRow, 3).Value = book.Author;
//            bookWorksheet.Cell(bookRow, 4).Value = book.Weight;
//            bookWorksheet.Cell(bookRow, 5).Value = book.Size;
//            bookRow++;
//        }

//        workbook.SaveAs("ShelvesAndBooks.xlsx");
//        Console.WriteLine("Data exported to ShelvesAndBooks.xlsx successfully!");
//    }
//}
