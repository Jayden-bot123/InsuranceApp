using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InsuranceApp;

class Program
{
    // Importing Random
    static Random random = new Random();

    // Global Variables
    static int laptopCounter = 0, desktopCounter = 0, otherCounter = 0;
    static string mostExpensiveDevice = "";
    static float totalInsuranceCost = 0, mostExpensiveDeviceCost = 0;

    


    // Constant Variables

    static List<string> CATEGORY = new List<string>() { "Laptop", "Desktop", "Other (such as smartphones or drone)" };
    static List<string> ERRORMESSAGES = new List<string>() { "ERROR: You must enter a number from 1 to 3", "ERROR: You must enter a valid number",
        "ERROR: The price must be between 0 and 10, 000", "ERROR: You must enter a number of devices between 1 and 100",
        "ERROR: Invalid device name entered. Only letters, digits, and spaces are allowed.", "ERROR: Invalid input." };

    // Methods and Functions
    static int CheckCategory()
    {
        int categoryNumber;
        
        while (true)
        {
            try
            {
                string menu = "\nEnter the device category:\n";

                for (int cat = 0; cat < CATEGORY.Count; cat++)
                {
                    // replaces categoryNumber with "cat" so it does not shadow the original variables and create errors
                    menu += $"{cat + 1}. {CATEGORY[cat]}\n"; 
                }

                Console.WriteLine(menu);
                categoryNumber = Convert.ToInt32(Console.ReadLine());

                if (categoryNumber >= 1 && categoryNumber <= 3)
                {
                    return categoryNumber;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ERRORMESSAGES[0]);
                    Console.ForegroundColor = ConsoleColor.White;

                }

            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ERRORMESSAGES[1]);
                Console.ForegroundColor = ConsoleColor.White;

            }

        }

    }


    static float CheckDeviceCost(string deviceName)
    {
        while (true)
        {
            Console.WriteLine($"\nEnter the cost for {deviceName}:");

            // Try to parse user input
            if (float.TryParse(Console.ReadLine(), out float deviceCost))
            {
                if (deviceCost > 0 && deviceCost < 10000)
                {
                    return deviceCost; // Return valid cost
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ERRORMESSAGES[2]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ERRORMESSAGES[1]);
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
    }


    static int CheckNumDevice(string deviceName)
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"\nEnter the number of {deviceName} devices:\n");

                int numDevice = Convert.ToInt32(Console.ReadLine());

                if (numDevice > 0 && numDevice < 100)
                {
                    return numDevice;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ERRORMESSAGES[3]);
                Console.ForegroundColor = ConsoleColor.White;
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ERRORMESSAGES[1]);
                Console.ForegroundColor = ConsoleColor.White;


            }
        }


    }

    static string CheckDeviceName()
    {
        string deviceName;
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

        while (true)
        {
            Console.WriteLine("Enter The Device Name:\n");

            deviceName = Console.ReadLine().ToUpper();

            // Check if the input is not empty and contains only letters, digits, or spaces
            if (!string.IsNullOrWhiteSpace(deviceName) && deviceName.All(ch => char.IsLetterOrDigit(ch) || ch == ' '))
            {
                return deviceName;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ERRORMESSAGES[4]);
            Console.ForegroundColor = ConsoleColor.White;

        }
    }

    static string Summary()
    {
        

        return "---------- Summary ----------\n" +
            $"Number of Laptops: {laptopCounter}\n" +
            $"Number of Desktops: {desktopCounter}\n" +
            $"Number of Other Devices: {otherCounter}\n\n" +
            $"The total value for insurance: ${totalInsuranceCost:F2}\n\n" +
            $"The most expensive device - {mostExpensiveDevice} @ {mostExpensiveDeviceCost:F2}";

    }

    static string CheckProceed()
    {
        string proceed;

        while (true)
        {
            Console.WriteLine("Press <Enter> to add another devices information or type 'Stop' to quit.");
            proceed = Console.ReadLine().ToUpper();

            if (proceed.Equals("") || proceed.Equals("STOP"))
            {
                return proceed;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ERRORMESSAGES[5]);
            Console.ForegroundColor = ConsoleColor.White;

        }


    }

    // Method to generate the random ID
    static string GenerateRandomId()
    {
        // Local Variables
        string digits = "0123456789";
        string part1 = "DEV";

        // Generating three random digits
        char[] part2 = new char[3]; // chooses 3 random numbers from the digits variable
        for (int num1 = 0; num1 < 3; num1++) // num1 meaning the first string of 3 digit number before the "@"
        {
            part2[num1] = digits[random.Next(digits.Length)]; //  this line generates a random selected digit between 0 and 9 with a specific range of numbers
        }

        string part3 = "@"; // String that separates the parts 1 and 2 from 3 and 4

        // Generating two random digits
        char[] part4 = new char[2]; // choose 2 random numbers from the digits variable
        for (int num2 = 0; num2 < 2; num2++) // num2 meaning the last 2 digit string of numbers after the "@"
        {
            part4[num2] = digits[random.Next(digits.Length)]; //  this line generates a random selected digit between 0 and 9 with a specific range of numbers
        }

        return $"{part1}{new string(part2)}{part3}{new string(part4)}";
    }


    static void OneDevice()
    {
        // Local Variables
        string deviceName;
        int categoryNumber, numDevice;
        float deviceInsurance;


        // Input the device name

        deviceName = CheckDeviceName();


        // Input the number of the device

        numDevice = CheckNumDevice(deviceName);


        // Input the cost of one device

        float devicecost = CheckDeviceCost(deviceName);


        // Input the category of the device (Laptop, Desktop, or Other)

        categoryNumber = CheckCategory();

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

        // Calculate insurance cost
        if (numDevice >= 5)
        {
            deviceInsurance = (5 * devicecost) + ((numDevice - 5) * devicecost * 0.90f);
        }
        else
        {
            deviceInsurance = numDevice * devicecost;
        }

        totalInsuranceCost += deviceInsurance;


        // shows which device is the most expensive
        if (deviceInsurance > mostExpensiveDeviceCost)
        {
            mostExpensiveDeviceCost = deviceInsurance;
            mostExpensiveDevice = deviceName;
        }

        Console.WriteLine("\n-------------------------------------------\n");
        // Display the Insurance Cost
        Console.WriteLine($"Device Name: {deviceName}\tDevice ID: {GenerateRandomId()}");
        Console.WriteLine($"Total cost for {numDevice} x {deviceName} devices is = {deviceInsurance:F2}");

        // Display depreciation
        Console.WriteLine($"Depreciation over 6 months:\n");

        for (int month = 1; month <= 6; month++)
        {
            devicecost *= 0.95f; // 5% depreciation per month

            Console.WriteLine($"Month: {month}\tValue Loss: {devicecost:F2}\n");
        }



        Console.WriteLine($"CATEGORY: {CATEGORY[categoryNumber - 1]}");
    }




    static void Main(string[] args)
    { 

        // Display ascii art
        Console.WriteLine("    ____                                            ___              \n   /  _/___  _______  ___________ _____  ________  /   |  ____  ____ \n   / // __ \\/ ___/ / / / ___/ __ `/ __ \\/ ___/ _ \\/ /| | / __ \\/ __ \\\n _/ // / / (__  ) /_/ / /  / /_/ / / / / /__/  __/ ___ |/ /_/ / /_/ /\n/___/_/ /_/____/\\__,_/_/   \\__,_/_/ /_/\\___/\\___/_/  |_/ .___/ .___/ \n                                                      /_/   /_/  \n");

        Console.WriteLine("This program lets users enter devices with their quantity, price, and category (laptop, desktop, or other). \n" +
            "It calculates insurance: If there is 5 or less devices, no insurance cost. If there is more than 5 devices, no charge for the first 5 devices, \nthen 10% for any extra. It also applies 5% depreciation over 6 months. \n" +
            "Finally, it shows the number of devices per category, total insurance cost, and the most expensive device.\n");
        Console.WriteLine("------------------------------------------------------------");


        CATEGORY.AsReadOnly();
        ERRORMESSAGES.AsReadOnly();

        string proceed = "";
        while (proceed.Equals(""))
        {
            // Call OneDevice Method
            OneDevice();

            
            proceed = CheckProceed();
        }

        Console.WriteLine(Summary());
    }

}
