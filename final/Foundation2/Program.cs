using System;
using System.Collections.Generic;

class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    public bool IsInUSA()
    {
        return country.Equals("USA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetAddressString()
    {
        return $"{streetAddress}\n{city}, {stateProvince}\n{country}";
    }
}

class Customer
{
    private string name;
    private Address address;

    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    public string GetShippingLabel()
    {
        return $"{name}\n{address.GetAddressString()}";
    }
}

class Product
{
    private string name;
    private int productId;
    private double price;
    private int quantity;

    public Product(string name, int productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    public double GetTotalPrice()
    {
        return price * quantity;
    }

    public string GetPackingLabel()
    {
        return $"{name} (ID: {productId})";
    }
}

class Order
{
    private List<Product> products;
    private Customer customer;

    public Order(List<Product> products, Customer customer)
    {
        this.products = products;
        this.customer = customer;
    }

    public double GetTotalPrice()
    {
        double totalPrice = 0;
        foreach (var product in products)
        {
            totalPrice += product.GetTotalPrice();
        }

        // Add shipping cost based on customer location
        totalPrice += customer.IsInUSA() ? 5 : 35;

        return totalPrice;
    }

    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (var product in products)
        {
            packingLabel += product.GetPackingLabel() + "\n";
        }
        return packingLabel.Trim();
    }

    public string GetShippingLabel()
    {
        return customer.GetShippingLabel();
    }
}

class Program
{
    static void Main()
    {
        // Create Address, Customer, and Product instances
        Address address1 = new Address("123 Main St", "Cityville", "CA", "USA");
        Customer customer1 = new Customer("John Doe", address1);

        Address address2 = new Address("456 Oak St", "Townsville", "NY", "Canada");
        Customer customer2 = new Customer("Jane Smith", address2);

        List<Product> products1 = new List<Product>
        {
            new Product("Laptop", 101, 800, 2),
            new Product("Mouse", 102, 25, 1),
            new Product("Keyboard", 103, 50, 1)
        };

        List<Product> products2 = new List<Product>
        {
            new Product("Smartphone", 201, 500, 1),
            new Product("Headphones", 202, 75, 1)
        };

        // Create Order instances
        Order order1 = new Order(products1, customer1);
        Order order2 = new Order(products2, customer2);

        // Display information for each order
        DisplayOrderInformation(order1);
        DisplayOrderInformation(order2);
    }

    static void DisplayOrderInformation(Order order)
    {
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order.GetPackingLabel());

        Console.WriteLine("\nShipping Label:");
        Console.WriteLine(order.GetShippingLabel());

        Console.WriteLine($"\nTotal Price: ${order.GetTotalPrice():F2}\n");

        Console.WriteLine(new string('-', 40));
    }
}
