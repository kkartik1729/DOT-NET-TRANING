using System;

public interface PaymentGateway
{
    public void ProcessPayment(decimal amount);
}