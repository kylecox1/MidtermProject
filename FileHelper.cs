using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Library
{
    public class FileHelper
    {

        public static List<Book> BookList()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book("Child Theif","Christopher Brom",Genre.Horror));
            books.Add(new Book("Lightning Theif","Rick Riordan",Genre.Fantasy));
            books.Add(new Book("Chains", "Laurie Halse Anderson", Genre.HistoricalFiction));
            books.Add(new Book("Cinder", "Marissa Meyer", Genre.SciFi));
            books.Add(new Book("Sherlock Holmes", "Arthur Conan Doyle", Genre.Mystery));
            books.Add(new Book("Buried Onions", "Gary Soto", Genre.RealisticFiction));
            books.Add(new Book("Fabio", "Ya Dream Man", Genre.Romance));
            books.Add(new Book("Coding for Dummies", "NikHil Abraham", Genre.NonFiction));
            books.Add(new Book("Green Eggs and Ham", "Dr Seuss", Genre.ChildrensBooks));
            books.Add(new Book("Foundation", "Isaac Asimo", Genre.SciFi));
            books.Add(new Book("Hyperion", "Dan Simmons", Genre.SciFi));
            books.Add(new Book("Cockoo Song", "Frances Hardinge", Genre.Horror));

            return books;
        }
        public static void WriteToFile()
        {
            string fileLocation = @"c:\code\books.txt";
            StreamWriter writeOnFile = new StreamWriter(fileLocation, true);
            foreach (var book in BookList())
            {
                writeOnFile.Write(book.Title + "|");
                writeOnFile.Write(book.Author + "|");
                writeOnFile.WriteLine(book.Category + "|");
            }

            writeOnFile.Flush();
            writeOnFile.Close();
        }

        //public static void AddBookToFile(string path, Book books)
        //{
        //    StreamWriter writer = new StreamWriter(path, true);
        //    StringBuilder builder = new StringBuilder();
        //    writer.WriteLine(builder.ToString());
        //    writer.Flush();
        //    writer.Close();
        //}

    }
}
