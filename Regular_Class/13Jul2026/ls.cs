// L- liskov Substitution principle
// a drive class shouldbe able to replace its base class
// without changing programs correction 

class Brid
{
    public void Fly()
    {
        Console.WriteLine("Flyingg");
    }
}

class Penguin : Brid
{
    public override void Dly()
    {
        throw new Exception("");
    }
}