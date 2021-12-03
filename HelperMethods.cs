using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class HelperMethods
    {
        public static void UserInterface()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            List<Book> books = FileHelper.GetFileBookList();

            Console.WriteLine("Welcome to the world's smallest library!");
            Console.WriteLine("");
            Console.WriteLine("These are our current selections:");
            Console.WriteLine("");

            foreach (var book in books)
            {
                Console.WriteLine($"  --- \"{ book.Title }\" by { book.Author } ---");
            }
            Console.WriteLine("");
            bool continueBrowsing = true;
            while (continueBrowsing == true)
            {
                Console.WriteLine("To continue, please enter:");
                Console.WriteLine("1. to search by author.");
                Console.WriteLine("2. to search by title.");
                Console.WriteLine("3. to return books.");
                Console.WriteLine("4. to donate books.");
                Console.WriteLine("Q to exit.");
                bool validSelection = false;
                while (validSelection == false)
                {

                    string userSearchSelection = Console.ReadLine();
                    if (userSearchSelection == "1")
                    {
                        validSelection = true;
                        bool continueAuthorSearch = true;
                        int userAuthorSelection;
                        while (continueAuthorSearch == true)
                        {
                            List<Book> authorSearchResults = AuthorSearch(books);
                            if (authorSearchResults.Count == 0)
                            {
                                Console.WriteLine("Sorry, we did not find any books with that author.");
                                Console.Write("Search by author again? (y/n): ");
                                continueAuthorSearch = GetYesOrNo();
                                continue;
                            }
                            Console.WriteLine("For that search, we have the following book(s):");
                            Console.WriteLine("");
                            int count = 1;
                            foreach (var book in authorSearchResults)
                            {
                                Console.WriteLine($"{ count }. \"{ book.Title }\" by { book.Author }");
                                count++;
                            }
                            Console.WriteLine("");
                            bool checkOutFromAuthorSearch = false;
                            Console.Write("Would you like to check out any of these? (y/n): ");
                            checkOutFromAuthorSearch = GetYesOrNo();
                            if (checkOutFromAuthorSearch == false)
                            {
                                Console.Write("Search by author again? (y/n): ");
                                continueAuthorSearch = GetYesOrNo();
                            }
                            else if (checkOutFromAuthorSearch == true)
                            {
                                bool validInput = false;
                                while (validInput == false)
                                {
                                    Console.Write("Please type the number of the book you would like: ");
                                    string userInput = Console.ReadLine();
                                    validInput = int.TryParse(userInput, out userAuthorSelection);
                                    if (validInput)
                                    {
                                        if (userAuthorSelection > authorSearchResults.Count || userAuthorSelection < 1)
                                        {
                                            Console.WriteLine("Sorry, that number was out of range.");
                                            validInput = false;
                                        }
                                        else
                                        {
                                            Book bookToCheckOut = authorSearchResults[userAuthorSelection - 1];
                                            Console.WriteLine($"Book number { userAuthorSelection } is " +
                                                $"\"{ bookToCheckOut.Title }\" by { bookToCheckOut.Author }");
                                            if (IsDue.CheckOutBook(bookToCheckOut))
                                            {
                                                bookToCheckOut.BookStatus = true;
                                                bookToCheckOut.DueDate = IsDue.DueDate();
                                                Console.WriteLine($"Looks like it was available! Please return it by { bookToCheckOut.DueDate }");
                                            }
                                        }
                                        continueAuthorSearch = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a whole number only.");
                                    }
                                }
                            }
                        }
                    }

                    else if (userSearchSelection == "2")
                    {
                        validSelection = true;
                        TitleSearch(books);

                    }
                    else if (userSearchSelection == "3")
                    {
                        validSelection = true;
                        Console.WriteLine("Logic to accept returns.");

                    }
                    else if (userSearchSelection == "4")
                    {
                        validSelection = true;
                        Console.WriteLine("Logic to accept donations.");
                    }
                    else if (userSearchSelection.ToLower() == "q")
                    {
                        validSelection = true;
                        continueBrowsing = false;
                    }
                    else
                    {
                        Console.Write("Sorry, that number was out of range. Try again please: ");
                    }
                }
                if (continueBrowsing == true)
                {
                    Console.Write("Continue browsing? (y/n): ");
                    continueBrowsing = GetYesOrNo();
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
            Console.Write("Please enter the title search term: ");
            string userTitleSearch = Console.ReadLine();
            List<Book> bookQuery = books.Where(p => p.Title.ToLower().Contains(userTitleSearch.ToLower())).ToList();
        }

        public static bool GetYesOrNo()
        {
            bool isValidYesNo = false;
            do
            {
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "n")
                {
                    return false;
                }
                else if (input.Trim().ToLower() == "y")
                {
                    return true;
                }
                else
                {
                    Console.Write("Please just enter a \"y\" or an \"n\": ");
                }
            } while (isValidYesNo == false);
            return false;
        }
    }
}
