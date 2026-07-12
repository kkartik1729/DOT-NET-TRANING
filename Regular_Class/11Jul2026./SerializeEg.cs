// serialization - converts an object into a form (JSON) so it can be saved and shared

using System;

using System.Text.Json;

class SerializeEg
{
    static void Main()
    {
        Employee e = new Employee(101, "Kartik", 125000);

        string json = JsonSerializer.Serialize(e);

        Console.WriteLine(json);

        //deceralize

        Employee e1 = JsonSerializer.Deserialize<Employee>(json);

        Console.WriteLine(e1.EmpName);
    }

}