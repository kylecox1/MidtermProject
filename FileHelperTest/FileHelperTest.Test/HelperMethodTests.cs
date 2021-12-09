using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Library;

namespace FileHelperTest.Test
{
    public class HelperMethodTests
    {
        [Fact]
        public void ListIsGiven_SelectedObjectFromListIsReturned()
        {
           
            
            List<Book> books = FileHelper.BookList();

            
            Book returnObject = HelperMethods.GetBookFromMainList(books, books[0]);

           
            Assert.Equal(returnObject, books[0]);
        }

        [Fact]
        public void FormatListBooks_ReturnsListOfBooks()
        {
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book("authorA", "titleA", true));
            bookList.Add(new Book("authorB", "titleB", true));

            StringBuilder actualResponse = HelperMethods.FormatListOfBooks(bookList);

            Assert.True(actualResponse.ToString().Contains("authorA") && actualResponse.ToString().Contains("authorB"));


        }















    }
}
