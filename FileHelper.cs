using System;
using System.Collections.Generic;

using System.Text;
using System.IO;


namespace Library
{
    class FileHelper
    {

        public static List<Book> BookList()
        {
            List<Book> books = new List<Book>();
            return books;
        }
        public static void WriteToFile()
        {
            string fileLocation = @"c:\code\books.txt";
            StreamWriter writeOnFile = new StreamWriter(fileLocation, true);
            writeOnFile.WriteLine(BookList());
            writeOnFile.Flush();
            writeOnFile.Close();
        }
        public static void AddBookToFile(string path, Book books)
        {
            StreamWriter writer = new StreamWriter(path, true);
            StringBuilder builder = new StringBuilder();
            builder.Append(books.Title);
            builder.Append("|");
            builder.Append(books.Author);
            builder.Append("|");
            builder.Append(books.Category);
            builder.Append("|");
            writer.WriteLine(builder.ToString());
            writer.Flush();
            writer.Close();
        }

    }
}
