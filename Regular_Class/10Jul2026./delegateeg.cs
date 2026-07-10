// delegate- type that holds a reference to a mrthod 
// similar to fuction pointer
// func



delegate void MessageDelegate(string msg);

class delegateeg
{



    static void Display(string message)
    {
        Console.WriteLine(message);
    }

    static void Main()
    {

        Func<int, int, int> add = (a, b) => a + b;
        Console.WriteLine(add(588, 561));

        MessageDelegate m = Display;
        m("Hello i am learning");
    }
}