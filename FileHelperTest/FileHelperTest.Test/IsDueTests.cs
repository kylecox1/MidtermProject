using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Library;

namespace FileHelperTest.Test
{
    public class IsDueTests
    {

        [Theory]
        [InlineData("tile", "author", true, false)]
        [InlineData("tile", "author", false, true)]

        public void CheckOutBook_ReturnsCorrectBookStatus(string title, string author, bool bookStatus, bool expectedResponse)
        {
            Book book = new Book(title, author, bookStatus);
            bool actualResponse = IsDue.CheckOutBook(book);

            Assert.Equal(expectedResponse, actualResponse);
        }

        [Theory]
        [InlineData("tile", "author", true, false)]
        [InlineData("tile", "author", false, true)]

        public void ReturnBook_ReturnsCorrectBookStatus(string title, string author, bool bookStatus, bool expectedResponse)
        {
            Book book = new Book(title, author, bookStatus);
            bool actualResponse = IsDue.CheckOutBook(book);

            Assert.Equal(expectedResponse, actualResponse);

        }

        [Fact]
        public void OverDue_ReturnsCorrectOverdueAnount()
        {
            Book book = new Book ("title","author",DateTime.Now.AddDays(-3) );
            decimal fine = .5m;
            string expectedResponse = "1.50";
            string actualResponse = IsDue.OverDue(book, fine);

            Assert.Equal(expectedResponse, actualResponse);

        }

        [Fact]
        public void OverDue_ReturnCorrectFineAmountIfTurnedInOnTime()
        {
            Book book = new Book("title", "author", DateTime.Now.AddDays(0));
            decimal fine = 0.5m;
            string expectedResponse = "0.00";
            string actualResponse = IsDue.OverDue(book, fine);

            Assert.Equal(expectedResponse, actualResponse);

        }

        [Fact]
        public void DueDate_ReturnsCorrectDueDate()
        {
            DateTime expectedResponse = DateTime.Now.Date.AddDays(14);
            DateTime actualResponse = IsDue.DueDate();

            Assert.Equal(expectedResponse, actualResponse);
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
