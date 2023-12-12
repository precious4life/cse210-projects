class FileHandler
{
    // Save data to a text file
    public void SaveToFile<T>(string filePath, List<T> items) where T : ReturnedItem
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (var item in items)
            {
                // Write each record as a line in the text file
                string line = $"{item.ProductName},{item.RemainingBalance},{item.CustomerIdentity},{item.QuantityReturned},{item.TotalAmountReceived}";
                writer.WriteLine(line);
            }

            Console.WriteLine("Data saved to file successfully!");
        }
    }

    // Load data from a text file
    public List<T> LoadFromFile<T>(string filePath) where T : ReturnedItem, new()
    {
        List<T> items = new List<T>();

        if (File.Exists(filePath))
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    // Read each line from the text file and create a returned item
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');
                    T returnedItem = new T
                    {
                        ProductName = values[0],
                        RemainingBalance = int.Parse(values[1]),
                        CustomerIdentity = values[2],
                        QuantityReturned = int.Parse(values[3]),
                        TotalAmountReceived = double.Parse(values[4])
                    };
                    items.Add(returnedItem);
                }

                Console.WriteLine("Data loaded from file successfully!");
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }

        return items;
    }
}
