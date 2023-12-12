using System;
using System.Collections.Generic;
using System.IO;



// Class for handling file operations

class Program
{
    static void Main()
    {
        // Instantiate classes
        StockManager stockManager = new StockManager();
        ReturnRecordKeeper returnRecordKeeper = new ReturnRecordKeeper();
        FileHandler fileHandler = new FileHandler();

        // Display menu to the user
        while (true)
        {
            Console.WriteLine("===== Stock Management System =====");
            Console.WriteLine("1. Add Returned Item");
            Console.WriteLine("2. Display Return Records");
            Console.WriteLine("3. Save Records to File");
            Console.WriteLine("4. Load Records from File");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Add a returned item
                    ReturnedItem returnedItem = new ReturnedItem
                    {
                        ProductName = "ProductA",
                        RemainingBalance = 100,
                        CustomerIdentity = "Customer123",
                        QuantityReturned = 5,
                        TotalAmountReceived = 250.0
                    };
                    stockManager.AddStockItem(returnedItem);
                    returnRecordKeeper.AddRecord(returnedItem);
                    break;

                case 2:
                    // Display return records
                    returnRecordKeeper.DisplayRecords();
                    break;

                case 3:
                    // Save records to a text file
                    fileHandler.SaveToFile("returnData.txt", returnRecordKeeper.ReturnedItems);
                    break;

                case 4:
                    // Load records from a text file
                    returnRecordKeeper.ReturnedItems = fileHandler.LoadFromFile<ReturnedItem>("returnData.txt");
                    break;

                case 5:
                    // Exit the program
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}

