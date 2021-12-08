using System;
using System.Collections.Generic;
using Xunit;
using Library;

namespace FileHelperTest.Test
{
    public class HelperMethodTests
    {
        [Fact]
        public void ListIsGiven_SelectedObjectFromListIsReturned()
        {
            // Arrange
            
            List<Book> books = FileHelper.BookList();

            // Act
            Book returnObject = HelperMethods.GetBookFromMainList(books, books[0]);

            // Assert
            Assert.Equal(returnObject, books[0]);
        }
    }
}
