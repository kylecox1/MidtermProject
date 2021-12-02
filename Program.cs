using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHelper.WriteToFile();
            UserInterface();
        }

        public static void UserInterface()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            List<Book> books = FileHelper.BookList();
            Console.WriteLine("Welcome to the library!");
            Console.WriteLine("");
            Console.WriteLine("These are our current selections:");
            Console.WriteLine("");
            foreach (var book in books)
            {
                Console.Write($"\"{ book.Title }\" by { book.Author }  |  "); 
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.Write("To continue, please type 1 to search by author or type 2 to search by title: ");
            bool validSelection = false;
            while (validSelection == false)
            {
                string userSearchSelection = Console.ReadLine();
                if (userSearchSelection == "1")
                {
                    validSelection = true;
                    List<Book> authorSearchResults = AuthorSearch(books);
                    if (authorSearchResults.Count == 0)
                    {
                        Console.WriteLine("Sorry, we did not find any books with that author.");
                    }
                    foreach (var book in authorSearchResults)
                    {
                        Console.WriteLine("For that author, we have the following book(s)");
                        Console.WriteLine(book.Author);
                    }
                }
                else if (userSearchSelection == "2")
                {
                    validSelection = true;
                    TitleSearch(books);

                }
                else
                {
                    Console.Write("Please just enter only a \"1\" or a \"2\": ");
                }
            }
            Console.WriteLine("Thanks for visiting us today! Press any key to exit.");
            Console.ReadKey();
        }

        public static List<Book> AuthorSearch(List<Book> books)
        {
            Console.Write("Please enter the author search term: ");
            string userAuthorSearch = Console.ReadLine();
            List<Book> bookQuery = books.Where(p => p.Author.ToLower().Contains(userAuthorSearch.ToLower())).ToList();
            return bookQuery;
        }

        public static void TitleSearch(List<Book> books)
        {
            Console.WriteLine("We are running title search.");
        }

    }
}
