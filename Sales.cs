using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SephoraSystem
{
    public class Sales
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        // Create a new order and add it to the order list
        public Order CreateOrder(int orderId, Customer customer)
        {
            var order = new Order(orderId, customer);
            Orders.Add(order);
            return order;
        }

        // Add products to the order
        public void AddProductsToOrder(Order order, Inventory inventory)
        {
            inventory.AddProductsToOrder(order);
        }

        // Handle payment
        public void HandlePayment(Order order)
        {
            Console.WriteLine("Select Payment Method:");
            Console.WriteLine("1. Cash");
            Console.WriteLine("2. Credit Card");
            int paymentChoice = int.Parse(Console.ReadLine());

            IPayment paymentMethod = null;

            if (paymentChoice == 1)
            {
                paymentMethod = new CashPayment();

                decimal amountPaid = 0;
                while (amountPaid < order.TotalAmount)
                {
                    Console.WriteLine($"Enter the amount paid by the customer (Total Amount: {order.TotalAmount:C}): ");
                    amountPaid = decimal.Parse(Console.ReadLine());

                    if (amountPaid < order.TotalAmount)
                    {
                        decimal remainingBalance = order.TotalAmount - amountPaid;
                        Console.WriteLine($"Insufficient funds. Please pay the remaining balance of {remainingBalance:C}.");
                    }
                    
                    else if (amountPaid > order.TotalAmount)
                    {
                        decimal change = amountPaid - order.TotalAmount;
                        Console.WriteLine($"Payment successful. The change to be returned is: {change:C}");
                    }
                    else
                    {
                        Console.WriteLine("Payment successful. Exact amount received.");
                    }
                }
            }
            
            else if (paymentChoice == 2)
            {
                paymentMethod = new CreditCardPayment();
                Console.WriteLine("Payment successful using Credit Card.");
            }
            else
            {
                Console.WriteLine("Invalid payment method selected.");
                return;
            }

            // Assign the chosen payment method to the order
            order.PaymentMethod = paymentMethod;

            // Proceed with the order processing
            order.ProcessOrder();
        }
    }
}