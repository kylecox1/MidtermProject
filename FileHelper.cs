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
            books.Add(new Book("Coding for Dummies", "Nikhil Abraham", Genre.NonFiction));
            books.Add(new Book("Green Eggs and Ham", "Dr Seuss", Genre.ChildrensBooks));
            books.Add(new Book("Foundation", "Isaac Asimov", Genre.SciFi));
            books.Add(new Book("Hyperion", "Dan Simmons", Genre.SciFi));
            books.Add(new Book("Cuckoo Song", "Frances Hardinge", Genre.Horror));
            books.Add(new Book("Overdue Checked Out Book", "A. Author", Genre.Horror, true, DateTime.Now.AddDays(-1)));
            books.Add(new Book("On-Time Checked Out Book", "B. Author", Genre.Romance, true, DateTime.Now.AddDays(1)));
            books.Add(new Book("Really Late Book", "C. Author", Genre.Fantasy, true, DateTime.Now.AddDays(-1000)));
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
            bool continueBookDonation = true;
            while (continueBookDonation == true)
            {
                string userTitle = "";
                bool validTitle = false;
                while (validTitle == false)
                {
                    Console.Write("Please enter your book's title: ");
                    userTitle = Console.ReadLine();
                    if (userTitle == null || userTitle == "")
                    {
                        Console.WriteLine("Please make sure to type something in.");
                    }
                    else
                    {
                        userTitle.Trim();
                        validTitle = true;
                    }
                }

                string userAuthor = "";
                bool validAuthor = false;
                while (validAuthor == false)
                {
                    Console.Write("Please enter your book's author: ");
                    userAuthor = Console.ReadLine();
                    if (userAuthor == null || userAuthor == "")
                    {
                        Console.WriteLine("Please make sure to type something in.");
                    }
                    else
                    {
                        userAuthor.Trim();
                        validAuthor = true;
                    }
                }

                string userGenre = "";
                bool validInput = false;
                do
                {
                    Console.Write("Please give a book Genre from the following types: Fantasy, Horror," +
                    " Mystery, HistoricalFiction, RealisticFiction, Romance, SciFi, NonFiction, ChildrensBooks: ");
                    string userInput = Console.ReadLine();
                    if (userInput == null || userInput == "")
                    {
                        Console.WriteLine("Please enter something.");
                    }
                    else if (userInput.Trim().ToLower() == "fantasy" ||
                        userInput.Trim().ToLower() == "horror" ||
                        userInput.Trim().ToLower() == "mystery" ||
                        userInput.Trim().ToLower() == "historicalfiction" ||
                        userInput.Trim().ToLower() == "realisticfiction" ||
                        userInput.Trim().ToLower() == "romance" ||
                        userInput.Trim().ToLower() == "scifi" ||
                        userInput.Trim().ToLower() == "nonfiction" ||
                        userInput.Trim().ToLower() == "childrensbooks")
                    {
                        userGenre = userInput.ToLower().Trim();
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Sorry but that wasn't a valid genre.");
                    }
                }
                while (validInput == false);
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
                Book newBook = new Book(userTitle, userAuthor, Enum.Parse<Genre>(userGenre));
                books.Add(newBook);
                Console.WriteLine($"Thanks for donating your copy of \"{newBook.Title}\"!");

                Console.Write("Donate another book? (y/n): ");
                continueBookDonation = HelperMethods.GetYesOrNo();
            }
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