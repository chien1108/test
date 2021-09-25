using HarshaBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarshaBank.DataAccessLayer
{
    public class CustomerDataAccesslayer : ICustomerDataAccesslayer
    {
        public static List<Customer> Customers = new List<Customer>()
        {
            new Customer()
            {
                Id = new Guid(),
                CustomerCode = 123,
                CustomerName = "AlicianHyb",
                Phone = "0867595956",
                Password = "1234Al"
            },

            new Customer()
            {
                Id = new Guid(),
                CustomerCode = 456,
                CustomerName = "Ali1",
                Phone = "0123456985",
                Password = "1234aA"
            },

            new Customer()
            {
                Id = new Guid(),
                CustomerCode = 789,
                CustomerName = "ali2",
                Phone = "0903833028",
                Password = "1234aA"
            }
        };
        public Guid AddCustomer(Customer customer)
        {
            Customers.Add(customer);
            return customer.Id;
        }

        public void AddRangeCustomer(List<Customer> customers)
        {
            Customers.AddRange(customers);
        }

        public bool DeleteCustomer(long code)
        {
            //single & singleOrDefault //
            Customer customer = Customers.Where(x => x.CustomerCode == code).SingleOrDefault();
            if (customer != null)
            {
                Customers.Remove(customer);
                return true;
            }
            return false; 
        }

        public bool DeleteCustomer(Guid customerID)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
                List<Customer> listCustomer = Customers.ToList();
                return listCustomer;
        }
        

        public List<Customer> GetCustomersByCondition(Func<Customer, bool> predicate)
        {
            var customers = Customers.Where(predicate);
            return customers.ToList();
        }

        public bool UpdateCustomer(Customer customer)
        {
            var customer2 = Customers.Where(x => x.CustomerCode == customer.CustomerCode).SingleOrDefault();
            if(customer2 != null)
            {
                customer2.CustomerName = customer.CustomerName;
                customer2.LandMark = customer.LandMark;
                customer2.Phone = customer.Phone;
                customer2.Address = customer.Address;
                return true;
            }
            return false;
        }
    }
}
