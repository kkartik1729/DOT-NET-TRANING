using System;
using System.Collections.Generic;

class Jul082026_Ass2
{
    public void display()
    {
        List<string> books = new List<string>()
        {
            "java",
            "python",
            "c",
            "c++",
            "dotnet"
        };

        Console.WriteLine("available books:");

        foreach (string book in books)
        {
            Console.WriteLine(book);
        }

        books.Add("dsa");

        books.Remove("c");

        Console.WriteLine("\nupdated book list:");

        foreach (string book in books)
        {
            Console.WriteLine(book);
        }

        Console.WriteLine("\ntotal books : " + books.Count);
    }
}