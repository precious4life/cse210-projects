// Base class representing a stock item
public class StockItem
{
    public string ProductName { get; set; }
    public int RemainingBalance { get; set; }
}

// Derived class representing a returned item
public class ReturnedItem : StockItem
{
    public string CustomerIdentity { get; set; }
    public int QuantityReturned { get; set; }
    public double TotalAmountReceived { get; set; }
}

// Interface for record-keeping
public interface IRecordKeeper
{
    void AddRecord(StockItem item);
    void DisplayRecords();
}

// Class implementing record-keeping for returned items
public class ReturnRecordKeeper : IRecordKeeper
{
    // List to store returned items
    private List<ReturnedItem> returnedItems;

    public ReturnRecordKeeper()
    {
        // Initialize the list in the constructor
        returnedItems = new List<ReturnedItem>();
    }

    public void AddRecord(StockItem item)
    {
        if (item is ReturnedItem returnedItem)
        {
            // Add returned items to the list
            returnedItems.Add(returnedItem);
            Console.WriteLine("Returned item added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid item type for return records.");
        }
    }

    public void DisplayRecords()
    {
        // Display return reports with specific formatting
        Console.WriteLine("Return Reports:");
        Console.WriteLine("{0,-15} {1,-10} {2,-20} {3,-15}",
            "Product Name", "Remaining Balance", "Customer Identity", "Total Amount Received");

        foreach (var item in returnedItems)
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-20} {3,-15}",
                item.ProductName, item.RemainingBalance, item.CustomerIdentity, item.TotalAmountReceived);
        }
    }

    // Property to access the list of returned items
    public List<ReturnedItem> ReturnedItems
    {
        get { return returnedItems; }
        set { returnedItems = value; }
    }

    // Save data to a text file
    public void SaveToFile(string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var item in returnedItems)
            {
                // Write each record as a line in the text file
                string line = $"{item.ProductName},{item.RemainingBalance},{item.CustomerIdentity},{item.QuantityReturned},{item.TotalAmountReceived}";
                writer.WriteLine(line);
            }

            Console.WriteLine("Data saved to file successfully!");
        }
    }

    // Load data from a text file
    public void LoadFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            // Clear existing items before loading
            returnedItems.Clear();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    // Read each line from the text file and create a returned item
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    ReturnedItem returnedItem = new ReturnedItem
                    {
                        ProductName = values[0],
                        RemainingBalance = int.Parse(values[1]),
                        CustomerIdentity = values[2],
                        QuantityReturned = int.Parse(values[3]),
                        TotalAmountReceived = double.Parse(values[4])
                    };
                    returnedItems.Add(returnedItem);
                }

                Console.WriteLine("Data loaded from file successfully!");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}
