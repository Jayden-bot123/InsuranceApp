using System;


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

    // Methods and Functions

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
        float deviceInsurance = 0; ;


        // Input the device name
        Console.WriteLine("Enter device name:");

        deviceName = Console.ReadLine();


        // Input the number of the device
        Console.WriteLine($"\nEnter the number of {deviceName}'s:");

        numDevice = Convert.ToInt32(Console.ReadLine());


        // Input the cost of one device
        Console.WriteLine($"\nEnter {deviceName} cost:");

        float devicecost = float.Parse(Console.ReadLine());


        // Input the category of the device (Laptop, Desktop, or Other)
        string menu = "\nEnter the device category:\n";


        for (int cat = 0; cat < CATEGORY.Count; cat++)
        {

            menu += $"{cat + 1}. {CATEGORY[cat]}\n"; // replaces categoryNumber with "cat" so it does not shadow the original one and create errors
        }

        Console.WriteLine(menu);
        categoryNumber = Convert.ToInt32(Console.ReadLine());


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
        if (numDevice > 5)
        {
            deviceInsurance += 5 * devicecost;

            deviceInsurance += (numDevice - 5) * devicecost * 0.9f;
        }

        else
        {
            deviceInsurance += numDevice * devicecost;
        }

        Console.WriteLine("\n-------------------------------------------\n");
        // Display the Insurance Cost
        Console.WriteLine($"Device Name: {deviceName}\t{GenerateRandomId()}");
        Console.WriteLine($"Total cost for {numDevice} x {deviceName} is = {deviceInsurance:F2} (with insurance)");

        // Display depreciation
        Console.WriteLine($"Depreciation over 6 months:\n");

        for (int month = 1; month <= 6; month++)
        {
            devicecost *= 0.95f; // 5% depreciation per month

            Console.WriteLine($"Month: {month}\tValue Lost: {devicecost:F2}\n");
        }

        

        Console.WriteLine($"CATEGORY: {CATEGORY[categoryNumber - 1]}");
        
    }




    static void Main(string[] args)
    {
        OneDevice();
    }
}

