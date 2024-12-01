using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SephoraSystem
{
    public class Inventory
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public Product GetProductById(int productId)
        {
            return Products.FirstOrDefault(p => p.ProductId == productId);
        }

        public void DisplayInventory()
        {
            foreach (var product in Products)
            {
                product.DisplayProductInfo();
            }
        }
        public void LoadSampleProducts(List<Category> categories)
        {
            AddProduct(new Makeup(1, "Lipstick", "Dior", 48.5m, categories[1], 100, "Red"));
            AddProduct(new Skincare(2, "Moisturizer", "Kiehl's", 67.0m, categories[0], 50, "Dry"));
            AddProduct(new Makeup(3, "Mascara", "Huda Beauty", 30.75m, categories[1], 200, "Black"));
            AddProduct(new Fragrance(4, "Eau de Parfum", "Prada", 135.0m, categories[2], 30, "Floral"));
            AddProduct(new HairCare(5, "Shampoo", "Loreal Paris", 40.0m, categories[3], 60, "Dry"));
            AddProduct(new NailCare(6, "Nail Polish", "Gucci", 35.0m, categories[4], 150, "Glossy"));
        }
        public void AddProductsToOrder(Order order)
        {
            Console.WriteLine("Select products to add to the order (0 to finish):");

            while (true)
            {
                Console.Write("Enter Product ID: ");
                int productId = int.Parse(Console.ReadLine());

                if (productId == 0)
                    break;

                var product = GetProductById(productId);
                if (product != null && product.StockQuantity > 0)
                {
                    order.AddProduct(product);
                    product.StockQuantity--;
                    Console.WriteLine($"{product.Name} added to the order.");
                }
                else
                {
                    Console.WriteLine("Invalid product or out of stock.");
                }
            }
        }
    }
}
