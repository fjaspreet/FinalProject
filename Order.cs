using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SephoraSystem
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
        public decimal TotalAmount { get; set; }
        public IPayment PaymentMethod { get; set; }

        // Constructor of the Order class
        public Order(int orderId, Customer customer)
        {
            OrderId = orderId;
            Customer = customer;
            PaymentMethod = null;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
            TotalAmount += product.Price;
        }

        public void DisplayOrderSummary()
        {
            Console.WriteLine($"Order ID: {OrderId}, Customer: {Customer.Name}");
            foreach (var product in Products)
            {
                Console.WriteLine($"- {product.Name} - {product.Brand} - {product.Price:C}");
            }
            Console.WriteLine($"Total: {TotalAmount:C}");
        }

        public void ProcessOrder()
        {
           
            if (PaymentMethod == null)
            {
                Console.WriteLine("Payment method has not been set.");
                return;
            }

            Console.WriteLine("\nProcessing Order...");
            DisplayOrderSummary();
            PaymentMethod.ProcessPayment(TotalAmount); 
        }
    }
}