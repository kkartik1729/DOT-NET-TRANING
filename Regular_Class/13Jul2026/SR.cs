// SOLID 
// S-single risponsibily (SRP)
// a class shou;f have only one reason to change
// perform only one responsibility


class SR
{
    public void CalcularteTotal()
    {
        Console.WriteLine("Calculate the total");
    }

    public void PrintInvoice()
    {
        Console.WriteLine("print the invioce");
    }

    public void DB()
    {
        Console.WriteLine("save to data base");
    }
}