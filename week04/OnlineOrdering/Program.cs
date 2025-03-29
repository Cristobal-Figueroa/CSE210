using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Address usaAddress = new Address("123 Main Street", "Seattle", "WA", "USA");
        Address internationalAddress = new Address("456 Maple Avenue", "Toronto", "Ontario", "Canada");
        
        Customer usaCustomer = new Customer("John Smith", usaAddress);
        Customer internationalCustomer = new Customer("Maria Rodriguez", internationalAddress);
        
        Product laptop = new Product("Laptop Pro X", "TECH-1001", 999.99m, 1);
        Product headphones = new Product("Wireless Headphones", "TECH-2002", 149.99m, 2);
        Product mouse = new Product("Gaming Mouse", "TECH-3003", 59.99m, 1);
        Product keyboard = new Product("Mechanical Keyboard", "TECH-4004", 129.99m, 1);
        Product monitor = new Product("4K Monitor", "TECH-5005", 349.99m, 1);
        
        Order order1 = new Order(usaCustomer);
        order1.AddProduct(laptop);
        order1.AddProduct(headphones);
        order1.AddProduct(mouse);
        
        Order order2 = new Order(internationalCustomer);
        order2.AddProduct(keyboard);
        order2.AddProduct(monitor);
        order2.AddProduct(headphones);
        
        Console.WriteLine("=== ORDER 1 ===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");
        Console.WriteLine();
        
        Console.WriteLine("=== ORDER 2 ===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}
