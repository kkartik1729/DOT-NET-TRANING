// collections- groups of object that can grow or shrink dynamically
//more flexible than array
//list-dynamic array automatically incress or decress
//dictionary 

using System.Collections.Generic;

class Collection
{
    static void Main()
    {
        List<String> names = new List<string>();

        names.Add("Kartik");
        names.Add("Pratik");

        foreach (String f in names)
        {
            Console.WriteLine(f);
        }
    }
}