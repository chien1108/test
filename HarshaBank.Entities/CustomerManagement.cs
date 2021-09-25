using System;

namespace HarshaBank.Entities
{
    public static class CustomerManagement
    {
        public static void Display(this Customer customer)
        {
            Console.WriteLine($"Customer code: {customer.CustomerCode}");
            Console.WriteLine($"Customer name: {customer.CustomerName}");
            Console.WriteLine($"Phone number: {customer.Phone}");
            Console.WriteLine($"Password: {customer.Password}");
        }
    }
}
