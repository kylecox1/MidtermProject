using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Book
    {
        private string title;
        public string Title { get; set; }

        private string author;
        public string Author { get; set; }

        private Genre category;
        public Genre Category { get; set; }

        public Book(string title, string author, Genre category)
        {
            Title = title;
            Author = author;
            Category = category;
        }
    }
}
