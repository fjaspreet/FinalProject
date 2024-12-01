using SephoraSystem;

class Program
{
    public static void Main(string[] arg)
    {

        Inventory inventory = new Inventory();
        Sales sales = new Sales();
        List<Customer> customers = new List<Customer>();

        // Load categories and sample products
        var categories = Category.GetDefaultCategories();
        inventory.LoadSampleProducts(categories);

        while (true)
        {
            Console.WriteLine("Welcome to Sephora Management System");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Create Order");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Customer.AddCustomer(customers);
                    break;

                case "2":
                    ViewInventory(inventory);
                    break;

                case "3":
                    CreateOrder(sales, customers, inventory);
                    break;

                case "4":
                    Console.WriteLine("Exiting... Thank you for using Sephora Management System!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }

    static void ViewInventory(Inventory inventory)
    {
        Console.WriteLine("View Inventory:");
        inventory.DisplayInventory();
    }


    // Create Order function with proper payment handling
    static void CreateOrder(Sales sales, List<Customer> customers, Inventory inventory)
    {
        Console.WriteLine("Create Order");

        // Get customer
        Console.Write("Enter Customer ID: ");
        int customerId = int.Parse(Console.ReadLine());
        var customer = customers.FirstOrDefault(c => c.Id == customerId);

        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        // Create order
        Console.Write("Enter Order ID: ");
        int orderId = int.Parse(Console.ReadLine());
        var order = sales.CreateOrder(orderId, customer);

        // Add products to order
        sales.AddProductsToOrder(order, inventory);

        Console.WriteLine($"Order Total: {order.TotalAmount:C}");

        // Handle payment
        sales.HandlePayment(order);
    }
}
