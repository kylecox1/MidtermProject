using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Book
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public Genre Category { get; set; }

        public bool BookStatus { get; set; }

        public DateTime DueDate { get; set; }

        public Book(string title, string author, Genre category)
        {
            Title = title;
            Author = author;
            Category = category;
        }
        public Book(string title, string author, Genre category, bool bookStatus, DateTime dueDate)
        {
            Title = title;
            Author = author;
            Category = category;
            BookStatus = bookStatus;
            DueDate = dueDate;
        }
    }
}
