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
            books.Add(new Book("Child Theif", "Christopher Brom", Genre.Horror));
            books.Add(new Book("Lightning Theif", "Rick Riordan", Genre.Fantasy));
            books.Add(new Book("Chains", "Laurie Halse Anderson", Genre.HistoricalFiction));
            books.Add(new Book("Cinder", "Marissa Meyer", Genre.SciFi));
            books.Add(new Book("Sherlock Holmes", "Arthur Conan Doyle", Genre.Mystery));
            books.Add(new Book("Buried Onions", "Gary Soto", Genre.RealisticFiction));
            books.Add(new Book("Fabio", "Ya Dream Man", Genre.Romance));
            books.Add(new Book("Coding for Dummies", "NikHil Abraham", Genre.NonFiction));
            books.Add(new Book("Green Eggs and Ham", "Dr Seuss", Genre.ChildrensBooks));
            books.Add(new Book("Foundation", "Isaac Asimov", Genre.SciFi));
            books.Add(new Book("Hyperion", "Dan Simmons", Genre.SciFi));
            books.Add(new Book("Cockoo Song", "Frances Hardinge", Genre.Horror));
            return books;
        }

        public static List<Book> GetFileBookList()
        {
            StreamReader reader = new StreamReader(@"c:\code\books.txt");
            List<Book> books = new List<Book>();
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] bookData = line.Split('|');
                Book newBook = new Book(bookData[0], bookData[1], Enum.Parse<Genre>(bookData[2]),
                    Boolean.Parse(bookData[3]), DateTime.Parse(bookData[4]));
                books.Add(newBook);
            }
            reader.Close();
            return books;
        }
      
        public static void OverWriteFile(List<Book> books)
        {
            string fileLocation = @"c:\code\books.txt";
            StringBuilder builder = new StringBuilder();
            foreach (var book in books)
            {
                builder.Append(book.Title + "|");
                builder.Append(book.Author + "|");
                builder.Append(book.Category + "|");
                builder.Append(book.BookStatus + "|");
                builder.Append(book.DueDate);
                builder.Append("\n");
            }
            File.WriteAllText(fileLocation, builder.ToString());
        }
      
        public static List<Book> DonateABook(List<Book> books)
        {
            Console.WriteLine("Please give a title:");
            string userTitle = Console.ReadLine().Trim();
            while (userTitle == null)
            {
                Console.WriteLine("Please make sure to type something in.");
                userTitle = Console.ReadLine().Trim();
            }
            Console.WriteLine("Please give the Authors name:");
            string userAuthor = Console.ReadLine().Trim();
            while (userAuthor == null)
            {
                Console.WriteLine("Please make sure to type something in.");
                userAuthor = Console.ReadLine().Trim();
            }

            Console.WriteLine("Please give a book Genre from the following types: Fantasy, Horror," +
            " Mystery, HistoricalFiction, RealisticFiction, Romance, SciFi, NonFiction, ChildrensBooks");
            string userGenre;
            bool notValidInput = true;
            do
            {
                if (userGenre == null)
                {
                    Console.WriteLine("Please write one of the choices above");
                    userGenre = Console.ReadLine().ToLower().Trim();
                }
                else if (userGenre == "fantasy" || userGenre == "horror" || userGenre == "mystery" ||
                    userGenre == "historicalfiction" ||
                    userGenre == "realisticfiction" || userGenre == "romance" || userGenre == "scifi"
                    || userGenre == "nonfiction" || userGenre == "childrensbooks")
                {
                    notValidInput = false;
                }
                else
                {
                    Console.WriteLine("Sorry but that wasn't a valid genre.");
                    userGenre = Console.ReadLine().ToLower().Trim();
                }
            }
            while (notValidInput == true);
            if (userGenre == "fantasy")
            {
                userGenre = "Fantasy";
            }
            if (userGenre == "horror")
            {
                userGenre = "Horror";
            }
            if (userGenre == "mystery")
            {
                userGenre = "Mystery";
            }
            if (userGenre == "historicalfiction")
            {
                userGenre = "HistoricalFiction";
            }
            if (userGenre == "realisticfiction")
            {
                userGenre = "RealisticFiction";
            }
            if (userGenre == "romance")
            {
                userGenre = "Romance";
            }
            if (userGenre == "nonfiction")
            {
                userGenre = "NonFiction";
            }
            if (userGenre == "childrensbooks")
            {
                userGenre = "ChildrensBooks";
            }
            if (userGenre == "scifi")
            {
                userGenre = "SciFi";
            }
            books.Add(new Book(userTitle, userAuthor, Enum.Parse<Genre>(userGenre)));
            return books;
        }
      
        public static void WriteToFile()
        {
            string fileLocation = @"c:\code\books.txt";
            StringBuilder builder = new StringBuilder();
            foreach (var book in GetFileBookList())
            {
                builder.Append(book.Title + "|");
                builder.Append(book.Author + "|");
                builder.Append(book.Category + "|");
                builder.Append(book.BookStatus + "|");
                builder.Append(book.DueDate);
                builder.Append("\n");
            }
            File.WriteAllText(fileLocation, builder.ToString());
        }
    }
}