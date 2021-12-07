using System;
using System.Collections.Generic;
using Xunit;
using Library;

namespace FileHelperTest.Test
{
    public class HelperMethodTests
    {
        [Fact]
        public void ListIsGiven_FormattedBuilderObjectIsReturned()
        {
            // Arrange
            HelperMethods subject = new HelperMethods();
            List<Book> books = FileHelper.BookList();

            // Act
            //FormatListOfBooks;

            // Assert

        }
    }
}
