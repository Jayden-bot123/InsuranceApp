using System;

namespace InsuranceApp;

class Program
{
    // Global Variables
    static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0;
    static string priciestDeviceName = "";
    static float totalInsuranceCost = 0, priciestDevice = 0;


    // Constant Variables

    static List<string> CATEGORY = new List<string>() { "Laptop\n", "Desktop\n", "Other\n" };

    // Methods and Functions


    static void OneDevice()
    {
        // Local Variables
        string deviceName; 
        int category, numDevice; 
        float devicePrice, deviceInsurance = 0; ;


        // Input the device name
        Console.WriteLine("Enter device name:");

        deviceName = Console.ReadLine();


        // Input the number of the device
        Console.WriteLine($"Enter the number of {deviceName}'s:");

        numDevice = Convert.ToInt32(Console.ReadLine());


        // Input the cost of one device
        Console.WriteLine($"Enter {deviceName} cost:");

        float devicecost = float.Parse(Console.ReadLine());


        // Input the category of the device (Laptop, Desktop, or Other)
        string menu = "Enter the device category:\n"; 

        int categoryNumber = 0;

        foreach (var cat in CATEGORY)
        {

            categoryNumber++;
            menu += $"{categoryNumber}.{cat}";
        }

        Console.WriteLine(menu);
        Console.ReadLine();


        // Adds the user input to a counter for the appropriate category

        if (categoryNumber == 1)
        {
            laptopCounter += numDevice;
            
        }
        else if (categoryNumber == 2)
        {
            desktopCounter += numDevice;
            
        }
        else
        {
            otherCounter += numDevice;
            
        }

        if (numDevice > 5)
        {
            deviceInsurance += 5 * devicecost;

            deviceInsurance += (numDevice - 5) * devicecost * 0.9f;
        }

        else
        {
            deviceInsurance += numDevice * devicecost;
        }


        // Display the Insurance Cost
        Console.WriteLine($"{deviceName}");
        Console.WriteLine($"Total cost for {numDevice} x {deviceName} is = {deviceInsurance:F2} (with insurance)");

        // Display depreciation
        Console.WriteLine($"Depreciation over 6 months:\n");

        for (int month = 1; month <= 6; month++)
        {
            devicecost *= 0.95f; // 5% depreciation per month

            Console.WriteLine($"Month: {month}\tValue Lost: {devicecost:F2}\n");
        }


        
    }




    static void Main(string[] args)
    {
       

        OneDevice();
    }
}

