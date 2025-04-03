using System;
using System.Collections.Generic;

class Program
{
    static List<Product> products = new List<Product>();

    static void Main()
    {
        InitializeProducts();

        while (true)
        {
            Console.WriteLine("Welcome to the Retail Store!");
            Console.WriteLine("Are you a Customer or Shop Owner? (Enter 'C' for Customer, 'S' for Shop Owner, 'Q' to Quit):");
            string role = Console.ReadLine().ToUpper();

            if (role == "C")
            {
                CustomerMenu();
            }
            else if (role == "S")
            {
                ShopOwnerMenu();
            }
            else if (role == "Q")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    static void InitializeProducts()
    {
        products.Add(new Product("Apple", 10, 12.0));
        products.Add(new Product("Banana", 20, 8.0));
        products.Add(new Product("Orange", 15, 15.0));
    }

    static void CustomerMenu()
    {
        List<Product> cart = new List<Product>();
        while (true)
        {
            Console.WriteLine("\nCustomer Menu:");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Add Product to Cart");
            Console.WriteLine("3. View Cart");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Back to Main Menu");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                ViewProducts();
            }
            else if (choice == "2")
            {
                AddProductToCart(cart);
            }
            else if (choice == "3")
            {
                ViewCart(cart);
            }
            else if (choice == "4")
            {
                Checkout(cart);
                break;
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    static void ShopOwnerMenu()
    {
        while (true)
        {
            Console.WriteLine("\nShop Owner Menu:");
            Console.WriteLine("1. View Stock");
            Console.WriteLine("2. Update Stock");
            Console.WriteLine("3. Add New Product");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                ViewProducts();
            }
            else if (choice == "2")
            {
                UpdateStock();
            }
            else if (choice == "3")
            {
                AddNewProduct();
            }
            else if (choice == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    static void ViewProducts()
    {
        Console.WriteLine("\nAvailable Products:");
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].Name} - Quantity: {products[i].Quantity}, Price: ₹{products[i].Price}");
        }
    }

    static void AddProductToCart(List<Product> cart)
    {
        ViewProducts();
        Console.Write("Enter the product number to add to cart: ");
        int productIndex = int.Parse(Console.ReadLine()) - 1;

        if (productIndex >= 0 && productIndex < products.Count)
        {
            Product product = products[productIndex];
            Console.Write("Enter the quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            if (quantity <= product.Quantity)
            {
                cart.Add(new Product(product.Name, quantity, product.Price));
                product.Quantity -= quantity;
                Console.WriteLine($"{quantity} {product.Name}(s) added to your cart.");
            }
            else
            {
                Console.WriteLine("Insufficient stock. Please try again.");
            }
        }
        else
        {
            Console.WriteLine("Invalid product number. Please try again.");
        }
    }

    static void ViewCart(List<Product> cart)
    {
        Console.WriteLine("\nYour Cart:");
        double total = 0;
        foreach (var item in cart)
        {
            double itemTotal = item.Quantity * item.Price;
            total += itemTotal;
            Console.WriteLine($"{item.Name} - Quantity: {item.Quantity}, Price: ₹{item.Price}, Total: ₹{itemTotal}");
        }
        Console.WriteLine($"Current Total: ₹{total}");
    }

    static void Checkout(List<Product> cart)
    {
        Console.WriteLine("\nCheckout:");
        double total = 0;
        foreach (var item in cart)
        {
            double itemTotal = item.Quantity * item.Price;
            total += itemTotal;
            Console.WriteLine($"{item.Name} - Quantity: {item.Quantity}, Price: ₹{item.Price}, Total: ₹{itemTotal}");
        }
        Console.WriteLine($"Final Total: ₹{total}");
        Console.WriteLine("Thank you for shopping with us!");
    }

    static void UpdateStock()
    {
        while (true)
        {
            Console.WriteLine("\nUpdate Stock Menu:");
            Console.WriteLine("1. View Current Stock");
            Console.WriteLine("2. Add to Product Quantity");
            Console.WriteLine("3. Back to Shop Owner Menu");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                ViewProducts();
            }
            else if (choice == "2")
            {
                ViewProducts();
                Console.Write("Enter the product number to update stock: ");
                int productIndex = int.Parse(Console.ReadLine()) - 1;

                if (productIndex >= 0 && productIndex < products.Count)
                {
                    Console.Write("Enter the quantity to add: ");
                    int quantity = int.Parse(Console.ReadLine());
                    products[productIndex].Quantity += quantity;
                    Console.WriteLine($"{quantity} units added to {products[productIndex].Name}. New quantity: {products[productIndex].Quantity}.");
                }
                else
                {
                    Console.WriteLine("Invalid product number. Please try again.");
                }
            }
            else if (choice == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }
    }

    static void AddNewProduct()
    {
        Console.Write("Enter the new product name: ");
        string productName = Console.ReadLine();
        Console.Write("Enter the quantity: ");
        int quantity = int.Parse(Console.ReadLine());
        Console.Write("Enter the price: ");
        double price = double.Parse(Console.ReadLine());

        products.Add(new Product(productName, quantity, price));
        Console.WriteLine($"{productName} added to the store with quantity {quantity} and price ₹{price}.");
    }
}

class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }

    public Product(string name, int quantity, double price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }
}
