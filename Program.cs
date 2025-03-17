using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            ProcessShipping();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    static void ProcessShipping()
    {
        DisplayWelcomeMessage();

        decimal weight = GetValidInput("Please enter the package weight:");
        if (IsPackageTooHeavy(weight)) return;

        decimal width = GetValidInput("Please enter the package width:");
        decimal height = GetValidInput("Please enter the package height:");
        decimal length = GetValidInput("Please enter the package length:");

        if (IsPackageTooBig(width, height, length)) return;

        decimal quote = CalculateShippingQuote(height, width, length, weight);
        DisplayQuote(quote);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");
    }

    static decimal GetValidInput(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            if (decimal.TryParse(Console.ReadLine(), out decimal value))
            {
                if (value <= 0)
                {
                    Console.WriteLine("Please enter a positive number.");
                    continue;
                }
                return value;
            }
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    static bool IsPackageTooHeavy(decimal weight)
    {
        if (weight > 50)
        {
            Console.WriteLine("Package too heavy to be shipped via Package Express. Have a good day.");
            return true;
        }
        return false;
    }

    static bool IsPackageTooBig(decimal width, decimal height, decimal length)
    {
        if (width + height + length > 50)
        {
            Console.WriteLine("Package too big to be shipped via Package Express.");
            return true;
        }
        return false;
    }

    static decimal CalculateShippingQuote(decimal height, decimal width, decimal length, decimal weight)
    {
        return (height * width * length * weight) / 100;
    }

    static void DisplayQuote(decimal quote)
    {
        Console.WriteLine($"Your estimated total for shipping this package is: ${quote:F2}");
        Console.WriteLine("Thank you!");
    }
}