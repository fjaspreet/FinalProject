using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SephoraSystem
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LoyaltyCardNumber { get; set; }

        public Customer(int id, string name, string email, string loyaltyCardNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            LoyaltyCardNumber = loyaltyCardNumber;
        }
        // Static method to add a new customer
        public static void AddCustomer(List<Customer> customers)
        {
            Console.WriteLine("Add New Customer");
            Console.Write("Enter Customer ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Customer Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Customer Email: ");
            string email = Console.ReadLine();
            Console.Write("Enter Loyalty Card Number: ");
            string loyaltyCard = Console.ReadLine();

            var customer = new Customer(id, name, email, loyaltyCard);
            customers.Add(customer);

            Console.WriteLine("Customer added successfully.");
        }
    }
}