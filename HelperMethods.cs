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
            bool continueBrowsing = true;
            while (continueBrowsing == true)
            {
                Console.WriteLine("");
                Console.WriteLine("These are our current selections:");
                Console.WriteLine("");

                foreach (var book in books)
                {
                    Console.WriteLine($"  --- \"{ book.Title }\" by { book.Author } ---");
                }
                Console.WriteLine("");
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
                                            Book searchedBook = authorSearchResults[userAuthorSelection - 1];
                                            Console.WriteLine($"Book number { userAuthorSelection } is " +
                                                $"\"{ searchedBook.Title }\" by { searchedBook.Author }");
                                            Book bookToCheckOut = GetBookFromMainList(books, searchedBook);

                                            if (IsDue.CheckOutBook(bookToCheckOut))
                                            {
                                                bookToCheckOut.BookStatus = true;
                                                bookToCheckOut.DueDate = IsDue.DueDate();
                                                Console.WriteLine($"Looks like it was available! You have checked out " +
                                                    $"\"{ bookToCheckOut.Title }.\" Please return it by { bookToCheckOut.DueDate }.");
                                            }
                                            else if (!IsDue.CheckOutBook(bookToCheckOut))
                                            {
                                                Console.WriteLine($"Sorry, \"{ bookToCheckOut.Title }\" is currently checked out. " +
                                                    $"It is due on { bookToCheckOut.DueDate }, please try back after then!");
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
                        bool continueTitleSearch = true;
                        int userTitleSelection;
                        while (continueTitleSearch == true)
                        {
                            List<Book> titleSearchResults = TitleSearch(books);
                            if (titleSearchResults.Count == 0)
                            {
                                Console.WriteLine("Sorry, we did not find any books with that title.");
                                Console.Write("Search by author again? (y/n): ");
                                continueTitleSearch = GetYesOrNo();
                                continue;
                            }
                            Console.WriteLine("For that search, we have the following book(s):");
                            Console.WriteLine("");
                            int count = 1;
                            foreach (var book in titleSearchResults)
                            {
                                Console.WriteLine($"{ count }. \"{ book.Title }\" by { book.Author }");
                                count++;
                            }
                            Console.WriteLine("");
                            bool checkOutFromTitleSearch = false;
                            Console.Write("Would you like to check out any of these? (y/n): ");
                            checkOutFromTitleSearch = GetYesOrNo();
                            if (checkOutFromTitleSearch == false)
                            {
                                Console.Write("Search by title again? (y/n): ");
                                continueTitleSearch = GetYesOrNo();
                            }
                            else if (checkOutFromTitleSearch == true)
                            {
                                bool validInput = false;
                                while (validInput == false)
                                {
                                    Console.Write("Please type the number of the book you would like: ");
                                    string userInput = Console.ReadLine();
                                    validInput = int.TryParse(userInput, out userTitleSelection);
                                    if (validInput)
                                    {
                                        if (userTitleSelection > titleSearchResults.Count || userTitleSelection < 1)
                                        {
                                            Console.WriteLine("Sorry, that number was out of range.");
                                            validInput = false;
                                        }
                                        else
                                        {
                                            Book searchedBook = titleSearchResults[userTitleSelection - 1];
                                            Console.WriteLine($"Book number { userTitleSelection } is " +
                                                $"\"{ searchedBook.Title }\" by { searchedBook.Author }.");
                                            Book bookToCheckOut = GetBookFromMainList(books, searchedBook);
                                            if (IsDue.CheckOutBook(bookToCheckOut))
                                            {
                                                bookToCheckOut.BookStatus = true;
                                                bookToCheckOut.DueDate = IsDue.DueDate();
                                                Console.WriteLine($"Looks like it was available! You have checked out " +
                                                    $"\"{ bookToCheckOut.Title }.\" Please return it by { bookToCheckOut.DueDate }.");
                                            }
                                            else if (!IsDue.CheckOutBook(bookToCheckOut))
                                            {
                                                Console.WriteLine($"Sorry, \"{ bookToCheckOut.Title }\" is currently checked out. " +
                                                    $"It is due on { bookToCheckOut.DueDate }, please try back after then!");
                                            }
                                        }
                                        continueTitleSearch = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please enter a whole number only.");
                                    }
                                }
                            }
                        }
                    }
                    else if (userSearchSelection == "3")
                    {
                        validSelection = true;
                        ReturnBook(books);
                    }
                    else if (userSearchSelection == "4")
                    {
                        validSelection = true;
                        FileHelper.DonateABook(books);
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
                    Console.Clear();
                }
            }
            FileHelper.OverWriteFile(books);
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

        public static List<Book> TitleSearch(List<Book> books)
        {
            Console.Write("Please enter the title search term: ");
            string userTitleSearch = Console.ReadLine();
            List<Book> bookQuery = books.Where(p => p.Title.ToLower().Contains(userTitleSearch.ToLower())).ToList();
            return bookQuery;
        }

        public static Book GetBookFromMainList(List<Book> books, Book searchedBook)
        {
            Book book = books.First(p => p.Title == searchedBook.Title);
            return book;
        }

        public static void ReturnBook(List<Book> books)
        {
            bool continueReturnSearch = true;
            int userReturnSelection;
            while (continueReturnSearch == true)
            {
                Console.WriteLine("Please enter part of the title of your book: ");
                string titleSearchTerm = Console.ReadLine();
                List<Book> bookQuery = books.Where(p => p.Title.ToLower().Contains(titleSearchTerm.ToLower())).ToList();
                if (bookQuery.Count < 1)
                {
                    Console.WriteLine("Hmm, not sure that one belongs to us. Try again? (y/n): ");
                    continueReturnSearch = GetYesOrNo();
                }
                else
                {
                    Console.WriteLine("For that term, our books include the following:");
                    Console.WriteLine("");
                    int count = 1;
                    foreach (var book in bookQuery)
                    {
                        Console.WriteLine($"{ count }. \"{ book.Title }\" by { book.Author }");
                        count++;
                    }
                    Console.WriteLine("");
                    bool bookOnList = false;
                    Console.Write("Is your book on this list? (y/n): ");
                    bookOnList = GetYesOrNo();
                    if (!bookOnList)
                    {
                        Console.WriteLine("Sorry, try search again? (y/n): ");
                        continueReturnSearch = GetYesOrNo();
                    }
                    else if (bookOnList)
                    {
                        bool validInput = false;
                        while (validInput == false)
                        {
                            Console.WriteLine("Please type the number of your book: ");
                            string userInput = Console.ReadLine();
                            validInput = int.TryParse(userInput, out userReturnSelection);
                            if (validInput)
                            {
                                if (userReturnSelection > bookQuery.Count || userReturnSelection < 1)
                                {
                                    Console.WriteLine("Sorry, that number was out of range.");
                                    validInput = false;
                                }
                                else
                                {
                                    Book searchedBook = bookQuery[userReturnSelection - 1];
                                    Console.WriteLine($"Book number { userReturnSelection } is " +
                                        $"\"{ searchedBook.Title }\" by { searchedBook.Author }.");
                                    Book bookToReturn = GetBookFromMainList(books, searchedBook);
                                    if (IsDue.CheckOutBook(bookToReturn))
                                    {
                                        Console.WriteLine("Looks like we already have our copy of this book! " +
                                            "Maybe it belongs to another library?");
                                        Console.WriteLine("Try search again? (y/n): ");
                                        continueReturnSearch = GetYesOrNo();
                                    }
                                    else if (!IsDue.CheckOutBook(bookToReturn))
                                    {
                                        if (bookToReturn.DueDate < DateTime.Now)
                                        {
                                            Console.WriteLine("Tsk tsk, that was overdue! Thanks for bringing it back though!");
                                            bookToReturn.DueDate = default(DateTime);
                                            bookToReturn.BookStatus = false;
                                            Console.WriteLine("Return another book? (y/n): ");
                                            continueReturnSearch = GetYesOrNo();
                                        }
                                        else if (bookToReturn.DueDate > DateTime.Now)
                                        {
                                            Console.WriteLine("Thanks for returning your book on time!");
                                            bookToReturn.DueDate = default(DateTime);
                                            bookToReturn.BookStatus = false;
                                            Console.WriteLine("Return another book? (y/n): ");
                                            continueReturnSearch = GetYesOrNo();
                                        }
                                    }
                                }
                            }
                            bookOnList = false;
                        }
                    }
                }
            }
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
