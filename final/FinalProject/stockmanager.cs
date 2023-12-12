// Manager class for stock management
public class StockManager
{
    // List to store stock items
    private List<StockItem> stockItems;

    public StockManager()
    {
        // Initialize the list in the constructor
        stockItems = new List<StockItem>();
    }

    public void AddStockItem(StockItem item)
    {
        // Add stock items to the list
        stockItems.Add(item);
        Console.WriteLine("Stock item added successfully!");
    }

    public void DisplayStockItems()
    {
        // Display stock items with specific formatting
        Console.WriteLine("Stock Items:");
        Console.WriteLine("{0,-15} {1,-10}", "Product Name", "Remaining Balance");

        foreach (var item in stockItems)
        {
            Console.WriteLine("{0,-15} {1,-10}", item.ProductName, item.RemainingBalance);
        }
    }
}