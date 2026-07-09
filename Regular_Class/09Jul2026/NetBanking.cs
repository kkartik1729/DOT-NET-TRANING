using System;

public class NetBanking : PaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Amount paid using net banking ");
    }
}