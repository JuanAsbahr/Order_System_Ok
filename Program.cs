using Order_System.Entities;
using Order_System.Entities.Enums;
using System;
using System.Globalization;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter Client Data");
        Console.Write("Name: ");
        string clientname = Console.ReadLine();
        Console.Write("Email: ");
        string emailclient = Console.ReadLine();
        Console.Write("Birth Date (DD/MM/YYYY): ");
        DateTime birthdate = DateTime.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Enter Order Data");
        Console.Write("Status: ");
        OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

        Client client = new Client(clientname, emailclient,birthdate);
        Order order = new Order(DateTime.Now, status, client);

        Console.WriteLine();
        Console.Write("How many items to this order? ");
        int qtd = int.Parse(Console.ReadLine());

        for (int i = 1; i <= qtd; i++)
        {
            Console.WriteLine($"Enter #{i} item data:");
            Console.Write("Product Name: ");
            string productname = Console.ReadLine();
            Console.Write("Product Price: $ ");
            double productprice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Product product = new Product(productname, productprice);

            Console.Write("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            OrderItem orderitem = new OrderItem(quantity, productprice, product);

            order.AddItem(orderitem);
        }
        Console.WriteLine();
        Console.WriteLine("Order Summary");
        Console.WriteLine(order);
    }
}