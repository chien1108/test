using HarshaBank.Entities;
using System;
using System.Collections.Generic;

namespace HarshaBank.BusinessLogicLayer
{
    public interface ICustomerBusinessLogicLayer
    {
        void AddCustomer(Customer customer);

        void AddRangeCustomer(List<Customer> customers);
        List<Customer> GetCustomers();
        List<Customer> GetCustomerByCondition(string name);
        List<Customer> GetCustomerByCondition(long code);
        List<Customer> GetCustomerByCondition(long code, string name);
        List<Customer> GetCustomerByCondition(Func<Customer, bool> predicate);
        string UpdateCustomer(long code);
        string DeleteCustomer(long code);
    }
}
