using System;
using System.Linq;

namespace HarshaBank.Entities
{
    public class Customer
    {
        private string _customerName, _password, _phone;
        private long _customerCode;
        public Guid Id { get; set; }
        public String Address { get; set; }

        public String LandMark { get; set; }

        public String City { get; set; }

        public String Country { get; set; }

        public String UserName { get; set; }

        public long CustomerCode
        {
            get => _customerCode;
            set
            {
                if (value > 0)
                {
                    _customerCode = value;
                }
                else
                {
                    throw new ArgumentException("CustomerCode must greater than 0");
                }
            }
        }
       
        public string CustomerName
        {
            get => _customerName;
            set
            {
                if (value.Length <= 40 && !string.IsNullOrEmpty(value))
                {
                    _customerName = value;
                }
                else
                {
                    throw new ArgumentException("Customer Name should not be null and less than 40 characters long.");
                }
            }
        }
 
        public string Password
        {
            get => _password;
            set
            {
                if (value.Length >= 6 && value.Any(char.IsUpper) && value.Any(char.IsLower) && value.Any(char.IsDigit))
                {
                    _password = value;
                }
                else
                {
                    throw new ArgumentException("Password is invalid");
                }
            }
        }

        public string Phone 
        {
            get => _phone; 
            set
            {
                if (int.TryParse(value, out int temp) && value.Length == 10)
                {
                    _phone = value;
                }
                else
                {
                    throw new ArgumentException("Phone number is syntax");
                }
            }
        }
 
    }
}