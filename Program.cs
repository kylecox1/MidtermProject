using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to the library!");
            FileHelper.WriteToFile();
            Console.ReadKey();
        }

    }
}
