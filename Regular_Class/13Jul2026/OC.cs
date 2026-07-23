// O- Open/Closed principal

using System.Security.Cryptography.X509Certificates;

class OC
{
    public void Pay(string method)
    {
        if (method == "CreditCard")
        {
            Console.WriteLine("Paidusing cridit card");
        }

        else if (method == "UPI")
        {
            Console.WriteLine("Paid Using UPI");
        }

        else if (method == "Cash")
        {
            Console.WriteLine("Paid Using cash in bank");
        }
      

    }

    Public void Process(Paymentt p)
        {
            p.pay();
        }

        static void Main()
    {
        OC c=new OC();
        c.Process(new Criditcard());
        c.Process(new UIntPtr());
    }
}