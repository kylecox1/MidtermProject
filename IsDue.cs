using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Library
{
    public class IsDue
    {
        public static bool CheckOutBook(Book book)
        {
            if (book.BookStatus == true)
            {
                return false;
            }
            else
            {
                book.BookStatus = true;
                return true;
            }
        }
        public static bool ReturnBook(Book book)
        {
            if (CheckOutBook(book) == false)
            {
                book.BookStatus = false;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static DateTime DueDate()
        {
            DateTime checkOutDay = DateTime.Now;
            TimeSpan twoWeeks = new TimeSpan(14, 0, 0, 0);
            DateTime dueDate = checkOutDay + twoWeeks;
            return dueDate;
        }
    }
}
