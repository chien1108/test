using HarshaBank.Entities;
using System;
using System.Collections.Generic;

namespace HarshaBank.DataAccessLayer
{
    public interface ICustomerDataAccesslayer
    {
        List<Customer> GetCustomers();

        List<Customer> GetCustomersByCondition(Func<Customer, bool> predicate);

        Guid AddCustomer(Customer customer);

        void AddRangeCustomer(List<Customer> customers);

        bool UpdateCustomer(Customer customer);

        bool DeleteCustomer(Guid customerID);
    }
}
