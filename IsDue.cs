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
        public static string OverDue(Book book, decimal fine)
        {
            DateTime today = DateTime.Now;
            int numberOfDays = (today - book.DueDate).Days;
            decimal amount = numberOfDays * fine;
            return amount.ToString("0.00");
        }


        public static DateTime DueDate()
        {
            DateTime checkOutDay = DateTime.Now.Date;
            TimeSpan twoWeeks = new TimeSpan(14, 0, 0, 0);
            DateTime dueDate = checkOutDay + twoWeeks;
            return dueDate;
        }
    }
}
