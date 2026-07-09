using System;

public class RuntimePoly
{
    public void Checkout(PaymentGateway payment, decimal amount)
    {
        payment.ProcessPayment(amount);
    }
}