using HarshaBank.DataAccessLayer;
using HarshaBank.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HarshaBank.BusinessLogicLayer
{
    public class CustomerBusinessLogicLayer : ICustomerBusinessLogicLayer
    {
        public void AddCustomer(Customer customer)
        {
            var dataAccess = new CustomerDataAccesslayer();
            customer.Id = new Guid();
            bool check;
            while (true)
            {
                try
                {
                    Console.Write("Input your AccountName: ");
                    string temp = Console.ReadLine();
                    var listCustomer = dataAccess.GetCustomers();
                    int a = 0;
                    foreach (var item in listCustomer)
                    {
                        if (item.CustomerName.Equals(temp))
                        {
                            Console.WriteLine("AccountName {temp} is exist please re input name");
                            a = 0;
                            break;
                        }
                        else
                        {
                            a++;
                        }
                    }
                    if (a != 0)
                    {
                        customer.CustomerName = temp;
                        break;
                    }
                    
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            

            long code;
            do
            {
                Console.Write("Input your Code: ");
                check = Int64.TryParse(Console.ReadLine(), out code);

                if (!check)
                {
                    Console.WriteLine("Customer Code Is valid code is long");
                }
            } while (!check);
            customer.CustomerCode = code;

            while(true)
            {

                try
                {
                    Console.Write("Input your Phone: ");
                    string temp = Console.ReadLine();
                    var listCustomer = dataAccess.GetCustomers();
                    int a = 0;
                    foreach (var item in listCustomer)
                    {
                        if (item.Phone.Equals(temp))
                        {
                            Console.WriteLine("Phone {temp} is exist please re input phone");
                            a = 0;
                            break;
                        }
                        else
                        {
                            a ++;
                        }
                    }
                    if(a != 0)
                    {
                        customer.Phone = temp;
                        break; 
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }    
            dataAccess.AddCustomer(customer);
        }

        public void AddRangeCustomer(List<Customer> customers)
        {
            var dataAccess = new CustomerDataAccesslayer();
            dataAccess.AddRangeCustomer(customers);
        }

        public string DeleteCustomer(long code)
        {
            var dataAccess = new CustomerDataAccesslayer();
            dataAccess.DeleteCustomer(code);
            return "Deleted!";
        }

        public List<Customer> GetCustomerByCondition(Func<Customer, bool> predicate)
        {
            var dataAccess = new CustomerDataAccesslayer();
            return dataAccess.GetCustomersByCondition(predicate);
        }

        public List<Customer> GetCustomerByCondition(string name)
        {
            var dataAccess = new CustomerDataAccesslayer();
            return dataAccess.GetCustomersByCondition(x => x.CustomerName == name);
        }

        public List<Customer> GetCustomerByCondition(long code)
        {
            var dataAccess = new CustomerDataAccesslayer();
            return dataAccess.GetCustomersByCondition(x => x.CustomerCode == code);
        }

        public List<Customer> GetCustomerByCondition(long code, string name)
        {
            var dataAccess = new CustomerDataAccesslayer();
            return dataAccess.GetCustomersByCondition(x => x.CustomerName == name && x.CustomerCode == code);
            
        }

        public List<Customer> GetCustomers()
        {
            var dataAccess = new CustomerDataAccesslayer();
            return dataAccess.GetCustomers();
        }

        public string UpdateCustomer(long code)
        {
            var dataAccess = new CustomerDataAccesslayer();
            List<Customer> listCustomer = dataAccess.GetCustomers();
            Customer customer = listCustomer.FirstOrDefault(x => x.CustomerCode == code);
            Console.Write("Input new name: ");
            string name = Console.ReadLine();
            if (name.Length != 0)
            {
                customer.CustomerName = name;
            }

            Console.Write("Input new Address: ");
            string address = Console.ReadLine();
            if (address.Length != 0)
            {
                customer.Address = address;
            }

            Console.Write("Input new LandMark: ");
            string landMark = Console.ReadLine();
            if (landMark.Length != 0)
            {
                customer.LandMark = landMark;
            }

            Console.Write("Input new City: ");
            string city = Console.ReadLine();
            if (city.Length != 0)
            {
                customer.City = city;
            }

            Console.Write("Input new Country: ");
            string country = Console.ReadLine();
            if (country.Length != 0)
            {
                customer.Address = country;
            }

            Console.Write("Input new Phone: ");
            string phone = Console.ReadLine();
            if (phone.Length != 0)
            {
                customer.Phone = phone;
            }

            Console.Write("Input new password: ");
            string password = Console.ReadLine();
            if (password.Length != 0)
            {
                customer.Password = password;
            }

            dataAccess.UpdateCustomer(customer);
            string message = "Updated!";
            return message;
        }
    }
}
