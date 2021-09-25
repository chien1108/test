using HarshaBank.BusinessLogicLayer;
using System;
using System.Linq;

namespace HarshaBank.Presentation
{
    public class BankManagerment
    {
        public void MenuBank()
        {
            int choise;
            var businessLogic = new CustomerBusinessLogicLayer();

            do
            {
                Console.Clear();
                Console.WriteLine("--------------------HARSHA BANK--------------------");
                Console.Write("\t\t1. Login\n");
                Console.Write("\t\t2. Exit\n");
                Console.WriteLine("---------------------------------------------------");
                bool check = false;
                do
                {
                    Console.Write("Please Enter Your Choise: ");
                    check = int.TryParse(Console.ReadLine(), out choise);
                    if (!check && !(choise >= 1 && choise <= 2))
                    {
                        Console.WriteLine("Your Choise Is Syntax, Choise is 1 or 2. Please Re enter your choise! ");
                    }
                } while (!check && !(choise >= 1 && choise <= 2));

                if (choise == 1)
                {
                    while(true)
                    {
                        try
                        {
                           SuccessMenu(ref businessLogic);
                            break;
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine("Account is " + ae.Message);
                        }
                    }
                  
                }
            } while (choise != 2);
        }

        private void SuccessMenu(ref CustomerBusinessLogicLayer businessLogic)
        {
            string userName, passWord;
            var function = new CustomerFunction();
            int choise;
            bool check = false;
            var listCustomer = businessLogic.GetCustomers();
            Console.WriteLine("--------------------HARSHA BANK LOGIN--------------------");
            Console.Write("\t\tUserName: ");
            userName = Console.ReadLine();
            Console.WriteLine();
            Console.Write("\t\tPassword: ");
            passWord = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");

            var checkIfExist = listCustomer.Where(x => x.CustomerName == userName && x.Password == passWord).SingleOrDefault();
            if (checkIfExist != null)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("--------------------HARSHA BANK--------------------");
                    Console.Write("\t\t1. Add Custommer\n");
                    Console.Write("\t\t2. Get All Existing Customer\n");
                    Console.Write("\t\t3. Find Customers\n");
                    Console.Write("\t\t4. Update Customer\n");
                    Console.Write("\t\t5. Delete Customer\n");
                    Console.Write("\t\t6. Exit\n");
                    Console.WriteLine("---------------------------------------------------");

                    do
                    {
                        Console.Write("Please Enter Your Choise: ");
                        check = int.TryParse(Console.ReadLine(), out choise);
                        if (!check && !(choise >= 1 && choise <= 6))
                        {
                            Console.WriteLine("Your Choise Is Syntax, Choise is 1,2,3,4,5,6. Please Re enter your choise! ");
                        }
                    } while (!check && !(choise >= 1 && choise <= 6));

                    switch (choise)
                    {
                        case 1: // add custommer
                            {
                                function.AddCustomer(ref businessLogic);
                                Console.WriteLine("Please input any key to exit mainmenu");
                                Console.ReadKey();
                                break;
                            }
                        case 2:
                            {
                                function.GetCustomer(businessLogic);
                                Console.WriteLine("Please input any key to exit mainmenu");
                                Console.ReadKey();
                                break;
                            }
                        case 3:
                            {
                                function.FindCustomer(businessLogic);
                                Console.WriteLine("Please input any key to exit mainmenu");
                                Console.ReadKey();
                                break;
                            }
                        case 4:
                            {
                                function.UpdateCustomer(businessLogic);
                                Console.WriteLine("Please input any key to exit mainmenu");
                                Console.ReadKey();
                                break;
                            }
                        case 5:
                            {
                                function.DeleteCustomer(ref businessLogic);
                                Console.WriteLine("Please input any key to exit mainmenu");
                                Console.ReadKey();
                                break;
                            }
                    }
                } while (choise != 6);
            }
            else
            {
                throw new ArgumentException("not exist");
            }
        }
      

    }
}
