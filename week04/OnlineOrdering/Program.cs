// This code was originally based on the Youtube Program
// Although this assignment had more specific requirements
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create Customer and Address
        Customer customer = new Customer("John");
        Address address1 = new Address("Ben Davis Rd", "Dallas", "Texas", "United States");

        // Create two orders
        Order order1 = new Order();
        Order order2 = new Order();

        // Adds products to the first order
        Product product1 = new Product("Banana", 5098724, 3.56f, 7);
        Product product2 = new Product("Eggs", 607892, 19.99f, 2);
        Product product3 = new Product("Bacon", 616532, 12.72f, 3);
        Product product4 = new Product("Pancake Batter", 476298, 8.99f, 3);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);
        order1.AddProduct(product4);

        // Adds products to the second order
        Product product5 = new Product("Whole Wheat Bread", 302456, 5.99f, 3);
        Product product6 = new Product("Chocolate", 345874, 5.99f, 4);
        Product product7 = new Product("Marshmallows", 987654, 4.49f, 2);
        Product product8 = new Product("Grahm Crackers", 142574, 6.89f, 3);
        order2.AddProduct(product5);
        order2.AddProduct(product6);
        order2.AddProduct(product7);
        order2.AddProduct(product8);

        // Prints customer and address info
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine($"Customer Name: {customer.CustomerName}");
        Console.WriteLine($"Address: {address1.StreetAddress}, {address1.City}, {address1.State}, {address1.Country}");
        Console.WriteLine();

        // Prints details for the first order
        Console.WriteLine("Order 1 Details:");
        foreach (var product in order1.GetProducts())
        {
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"--Product ID: {product.ProductID}");
            Console.WriteLine($"--Price Per Product: {product.Price}");
            Console.WriteLine($"--Amount Purchased: {product.Quantity}");
            Console.WriteLine($"Total Price of Product: {product.TotalProductPrice}");
        }
        Console.WriteLine(order1.GetSummary(address1));
        Console.WriteLine();

        // Prints details for the second order
        Console.WriteLine("Order 2 Details:");
        foreach (var product in order2.GetProducts())
        {
            Console.WriteLine($"Product Name: {product.ProductName}");
            Console.WriteLine($"--Product ID: {product.ProductID}");
            Console.WriteLine($"--Price Per Product: {product.Price}");
            Console.WriteLine($"--Amount Purchased: {product.Quantity}");
            Console.WriteLine($"Total Price of Product: {product.TotalProductPrice}");
        }
        Console.WriteLine(order2.GetSummary(address1));
    }
}