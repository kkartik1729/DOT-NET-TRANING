using System;

public class CreditPayment : PaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Amount paid using Credit card");
    }
}