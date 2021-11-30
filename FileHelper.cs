using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Library
{
    public static class FileHelper
    {
        public static List<Books> BuildBookList(string path)
        {
            List<Books> bookList = new List<Books>();
            using (StreamReader reader = new StreamReader(path))
            {
                string lineText;
                while ((lineText = reader.ReadLine()) != null)
                {
                    string[] items = lineText.Split('|');
                }

            }
        }
    }
}
