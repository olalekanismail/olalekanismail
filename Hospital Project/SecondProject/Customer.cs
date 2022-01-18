using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondProject
{
    public class Customer : Person
    {
        public string CustomerID { get; }
        public string Id;
        
        public static List<Customer> customers = new List<Customer>();
        public static List<Rooms> rooms1 = new List<Rooms>();
        public Customer(string firstname, string lastName, string middleName,string phonenumber, int age, string address) : base(firstname, lastName, middleName, phonenumber, age, address)
        {
            CustomerID = GenerateID();
           
        }
        public void PrintCustomerID()
        {
            Console.WriteLine($"Dear {Firstname} {LastName} welcome to {Person.HotelName}...your CUSTOMER ID IS {CustomerID}");
        }
        private string GenerateID()
        {
            Random rand = new Random();
            return $"{"CT" + rand.Next(1, 40).ToString("00")}";
        }
        public static void PrintCustomerDetails()
        {
            for (int k = 0; k < customers.Count; k++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{k+1}..{customers[k].Firstname}....{customers[k].LastName}...{customers[k].CustomerID}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        
    }
}
