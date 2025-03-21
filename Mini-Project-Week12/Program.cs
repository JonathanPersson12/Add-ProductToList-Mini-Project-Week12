/*
 * 1. Create a Class that ask user for category, product name and price.
 * 2. make a list so the item can be added to the list.
 * 3. create so user can add items until they are done and write q or quit to stop.
 * 4. when user is done summarize the price and sort the list form low to high price. 
 when presnting the list.
 * 5. when done ask user if they want to add more items or quit.
*/



// Represents a product
public class Product
{
    public string Category { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }

    public Product(string category, string productName, double price)
    {
        Category = category;
        ProductName = productName;
        Price = price;
    }
}

// Represents a list of products
public class ProductList
{
    public List<Product> products = new List<Product>();

    // Adds a product to the list
    public void AddProduct()

    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Follow these steps to enter new product | To quit - enter: 'q' ");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter a Category: ");
            string category = Console.ReadLine();
            if (string.IsNullOrEmpty(category) || category.ToLower() == "q")
                break;

            Console.Write("Enter Product Name: ");
            string productName = Console.ReadLine();
            if (string.IsNullOrEmpty(productName))
            {
                Console.WriteLine("Product name cannot be empty. Please try again. ");
                Console.ResetColor();
                continue;
            }

            Console.Write("Enter a Price: ");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid price. Please try again.");
                Console.ResetColor();
                continue;
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product added successfully!");
            Console.ResetColor();

            Console.WriteLine();

            products.Add(new Product(category, productName, price));

        }
    }

    // Displays the list of products sorted by price and the total price of all products
    public void DisplaySummary()
    {
        var sorted = products.OrderBy(p => p.Price).ToList();
        double totalPrice = sorted.Sum(p => p.Price);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nProducts List (sorted by price):");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-------------------------------------------------");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("{0,-20} {1,-20} {2,-20}", "Category", "Product Name", "Price");
        Console.ResetColor();

        Console.WriteLine();

        foreach (var product in sorted)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0,-20} {1,-20} {2,-20:C}", product.Category, product.ProductName, product.Price);
            Console.ResetColor();
        }

        Console.WriteLine($"\nTotal Price: {totalPrice:C}");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("-------------------------------------------------");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("To enter a new product - enter: 'p' | To quit - enter: 'q' ");
        Console.ResetColor();

        string input = Console.ReadLine();
        if (input.ToLower() == "p")
        {
            AddProduct();
            DisplaySummary();
        }
        else if (input.ToLower() == "q")
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Thank you for using the application. Goodbye!");
            Console.ResetColor();
        }
    }
}

// Main class
public class Program
{
    public static void Main()
    {
        ProductList productList = new ProductList();
        productList.AddProduct();
        productList.DisplaySummary();
    }
}


