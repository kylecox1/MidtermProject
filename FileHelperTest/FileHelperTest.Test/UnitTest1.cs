using System;
using Xunit;
using Library;
using System.Collections.Generic;

namespace FileHelperTest.Test
{
    public class UnitTest1
    {
        [Fact]
        public static void GetFileBookList_CreatesListFromFileUsingLoop()
        {
            List<Book> books = new List<Book>();

            books = FileHelper.GetFileBookList();

            Assert.True(books.Count > 0);
        }
    }
}
