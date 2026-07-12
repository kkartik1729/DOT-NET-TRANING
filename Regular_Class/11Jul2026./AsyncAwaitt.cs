//async- needed for operations which take sometime 

//without async,the application waits until the work finishes

using System;

using System.Threading.Tasks;

public class AsyncAwaitt
{
    static async Task Main()
    {
        Console.WriteLine("LOading employee data details.....");

        await LoadEmployee();

        Console.WriteLine("Completed");
    }

    static async Task LoadEmployee()
    {
        await Task.Delay(2000);

        Console.WriteLine("Employee loaded");
    }
}