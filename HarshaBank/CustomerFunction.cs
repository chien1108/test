using HarshaBank.BusinessLogicLayer;
using HarshaBank.Entities;
using System;

namespace HarshaBank.Presentation
{
    public class CustomerFunction
    {
        public void AddCustomer(ref CustomerBusinessLogicLayer businessLogic)
        {
            Customer customer = new Customer();
            businessLogic.AddCustomer(customer);
            Console.WriteLine("Add customer Done!");
        }
        public void GetCustomer(CustomerBusinessLogicLayer businessLogic)
        {
            Console.Clear();
            Console.WriteLine("--------------------Select All--------------------");
            var listCustomerGet = businessLogic.GetCustomers();
            foreach (var item in listCustomerGet)
            {
                Console.WriteLine($"CustomerID: {item.Id}");
                Console.WriteLine($"Code: {item.CustomerCode}");
                Console.WriteLine($"Name: {item.CustomerName}");
                Console.WriteLine($"Address: {item.Address}");
                Console.WriteLine($"Landmark: {item.LandMark}");
                Console.WriteLine($"City: {item.City}");
                Console.WriteLine($"Country: {item.Country}");
                Console.WriteLine($"Phone: {item.Phone}");
                Console.WriteLine($"Password: {item.Password}");
                Console.WriteLine("---------------------------------------------------");
            }
        }
        public void FindCustomer(CustomerBusinessLogicLayer businessLogic)
        {
            bool check;
            int choise;
            Console.Clear();
            Console.WriteLine("--------------------Search--------------------");

            do
            {
                Console.WriteLine("\t\t1. Search by name");
                Console.WriteLine("\t\t2. Search by code");
                Console.WriteLine("\t\t3. Exit");
                Console.WriteLine("---------------------------------------------------");
                do
                {
                    Console.Write("Please Enter Your Choise: ");
                    check = int.TryParse(Console.ReadLine(), out choise);
                    if (!check && !(choise >= 1 && choise <= 3))
                    {
                        Console.WriteLine("Your Choise Is Syntax, Choise is 1,2 or 3. Please Re enter your choise! ");
                    }
                } while (!check && !(choise >= 1 && choise <= 3));
                switch (choise)
                {
                    case 1:
                        {
                            Console.Write("Enter the name for search");
                            string nameCustomerSearch = Console.ReadLine();
                            //find by name or code or by predicate, we have polymorphism here, feel free to change the parameter but only in range of name and code or predicate
                            var listCustomerGet = businessLogic.GetCustomerByCondition(nameCustomerSearch);
                            foreach (var item in listCustomerGet)
                            {
                                Console.WriteLine($"CustomerID: {item.Id}");
                                Console.WriteLine($"Code: {item.CustomerCode}");
                                Console.WriteLine($"Name: {item.CustomerName}");
                                Console.WriteLine($"Address: {item.Address}");
                                Console.WriteLine($"Landmark: {item.LandMark}");
                                Console.WriteLine($"City: {item.City}");
                                Console.WriteLine($"Country: {item.Country}");
                                Console.WriteLine($"Phone: {item.Phone}");
                                Console.WriteLine($"Password: {item.Password}");
                                Console.WriteLine("----------------------------------------------");
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter the code for search");
                            long codeCustomerSearch;
                            bool checkCode = Int64.TryParse(Console.ReadLine(), out codeCustomerSearch);
                            //find by name or code or by predicate, we have polymorphism here, feel free to change the parameter but only in range of name and code or predicate
                            var listCustomerGet = businessLogic.GetCustomerByCondition(codeCustomerSearch);
                            foreach (var item in listCustomerGet)
                            {
                                Console.WriteLine($"CustomerID: {item.Id}");
                                Console.WriteLine($"Code: {item.CustomerCode}");
                                Console.WriteLine($"Name: {item.CustomerName}");
                                Console.WriteLine($"Address: {item.Address}");
                                Console.WriteLine($"Landmark: {item.LandMark}");
                                Console.WriteLine($"City: {item.City}");
                                Console.WriteLine($"Country: {item.Country}");
                                Console.WriteLine($"Phone: {item.Phone}");
                                Console.WriteLine($"Password: {item.Password}");
                                Console.WriteLine("----------------------------------------------");
                            }
                            break;
                        }
                }
            } while (choise != 3);
           
        }
        public void UpdateCustomer(CustomerBusinessLogicLayer businessLogic)
        {
            Console.Clear();
            Console.WriteLine("--------------------Update--------------------");
            var listCustomerGet = businessLogic.GetCustomers();
            foreach (var item in listCustomerGet)
            {
                Console.WriteLine($"CustomerID: {item.Id}");
                Console.WriteLine($"Code: {item.CustomerCode}");
                Console.WriteLine($"Name: {item.CustomerName}");
                Console.WriteLine($"Address: {item.Address}");
                Console.WriteLine($"Landmark: {item.LandMark}");
                Console.WriteLine($"City: {item.City}");
                Console.WriteLine($"Country: {item.Country}");
                Console.WriteLine($"Phone: {item.Phone}");
                Console.WriteLine($"Password: {item.Password}");
                Console.WriteLine("----------------------------------------------");
            }
            Console.WriteLine("Enter customer code that you want to update: ");
            long customerCode = long.Parse(Console.ReadLine());
            Console.WriteLine($"You Updating Customer have code is {customerCode}, you not updat is enter ");
            Console.WriteLine(businessLogic.UpdateCustomer(customerCode));
        }
        public void DeleteCustomer(ref CustomerBusinessLogicLayer businessLogic)
        {
            Console.Clear();
            Console.WriteLine("-------------------Delete-------------------");
            var listCustomerGet = businessLogic.GetCustomers();
            foreach (var item in listCustomerGet)
            {
                Console.WriteLine($"CustomerID: {item.Id}");
                Console.WriteLine($"Code: {item.CustomerCode}");
                Console.WriteLine($"Name: {item.CustomerName}");
                Console.WriteLine($"Address: {item.Address}");
                Console.WriteLine($"Landmark: {item.LandMark}");
                Console.WriteLine($"City: {item.City}");
                Console.WriteLine($"Country: {item.Country}");
                Console.WriteLine($"Phone: {item.Phone}");
                Console.WriteLine($"Password: {item.Password}");
                Console.WriteLine("----------------------------------------------");
            }
            Console.Write("Enter customer code that you want to delete: ");
            long customerCode = long.Parse(Console.ReadLine());
            Console.WriteLine(businessLogic.DeleteCustomer(customerCode));
        }
    }
}
