using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        static void Rubric()
        {
            //Library Terminal

            //Write a console program which allows a user to search a library catalog and reserve
            //books..

            //● Your solution must include some kind of book class with a title, author,---
            //status, and due date if checked out.---

            //○ Status should be On Shelf or Checked out (or other statuses you can
            //imagine). For additional practice, use an Enum if you want!

            //● 12 items minimum, they must be stored in a text file your program reads in.
            //● Allow the user to:
            //○ Display the entire list of books.Format it nicely.
            //○ Search for a book by author.
            //○ Search for a book by title keyword.
            //○ Select a book from the list to check out.
            //■ If it’s already checked out, let them know.
            //■ If not, check it out to them and set the due date to 2 weeks from
            //today.

            //○ Return a book. (You can decide how that looks/what questions it asks.)

            //● When the user quits, save the current library book list(including due dates
            //and statuses) to the text file so the next time the program runs, it
            //remembers.

            //Optional enhancements:
            //● (Moderate) Include an option to add to the book list, which then outputs to
            //the book file.
            //● (Hard) Create a full GUI.
        }
    }
}
