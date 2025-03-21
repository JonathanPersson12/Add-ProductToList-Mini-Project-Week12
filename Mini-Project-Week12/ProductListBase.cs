/*
 * 1. Create a Class that ask user for category, product name and price.
 * 2. make a list so the item can be added to the list.
 * 3. create so user can add items until they are done and write q or quit to stop.
 * 4. when user is done summarize the price and sort the list form low to high price. 
 when presnting the list.
*/

public class ProductListBase
{
    private List<Product> products = new List<Product>();

    public void AddProduct()
    {
        while (true)
        {
            Console.WriteLine("Please enter a category for product to continue: ");
            string category = Console.ReadLine();
            if (string.IsNullOrEmpty(category) || category.ToLower() == "q" || category.ToLower() == "quit")
                break;

            Console.WriteLine("Please enter product name for product to continue: ");
            string productName = Console.ReadLine();
            if (string.IsNullOrEmpty(productName))
            {
                Console.WriteLine("Product name cannot be empty. Please try again.");
                continue;
            }

            Console.WriteLine("Lastly enter the product's price: ");
            if (!double.TryParse(Console.ReadLine(), out double price))
            {
                Console.WriteLine("Invalid price entered, please try again.");
                continue;
            }

            products.Add(new Product(category, productName, price));
        }

        // Summarize and sort the products
        double totalPrice = products.Sum(p => p.Price);
        var sortedProducts = products.OrderBy(p => p.Price).ToList();

        Console.WriteLine("Summary:");
        Console.WriteLine($"Total Price: {totalPrice}");
        Console.WriteLine("Products sorted by price (low to high):");
        foreach (var product in sortedProducts)
        {
            Console.WriteLine($"Category: {product.Category}, Product Name: {product.ProductName}, Price: {product.Price}");
        }
    }
}
