
using System;
using System.Globalization;

namespace FtoC
{
    class Program
    {
        static void Main()
        {
            string celius = "";
            string userChoice = "";
            var culture = new CultureInfo("de-DE");
            while (userChoice != "1" || userChoice != "2") //loop so long until user picks correctly
            {
                Console.WriteLine("Press C to convert temperatur from Celsius to Fahrenheit");
                Console.WriteLine("Press F to convert temperatur from Fahrenheit to Celsius");
                userChoice = Console.ReadLine();
                if (userChoice.ToUpper() == "F") //celsius to fahrenheit converter
                {
                    Console.WriteLine("Please enter the temperatur in Celsius you want to convert to Fahrenheit.");
                    celius = Console.ReadLine();
                    double c;
                    bool celiusToFahren = double.TryParse(celius, NumberStyles.Any, culture, out c); //check if only numbers are entered. convert , to . correct culture

                    if (celiusToFahren == false)
                    {
                        Console.WriteLine("Please use numbers only");
                        Console.WriteLine("");
                    }
                    else
                    {
                        double answer = ((9.0 / 5.0) * c) + 32; //math from c to f.
                        Console.WriteLine(c + " °C is " + answer + " °F.");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }
                }

                else if (userChoice.ToUpper() == "C") //fahrenheit to celsius converter
                {
                    Console.WriteLine("Please enter the temperatur in Fahrenheit you want to convert to Celsius.");
                    string fahrenheit = Console.ReadLine();
                    double f;
                    bool fahrenToCelsius = double.TryParse(fahrenheit, NumberStyles.Any, culture, out f);

                    if (fahrenToCelsius == false)
                    {
                        Console.WriteLine("Please use numbers only.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        double answer = (5.0 / 9.0) * (f - 32);
                        Console.WriteLine(f + " °F is " + answer + " °C.");
                        Console.WriteLine("");
                        Console.WriteLine("");
                        Console.WriteLine("");
                    }
                }

                else //to deal with all other cases that user enters.
                {
                    Console.WriteLine("Oops! Incorrect number. Please try again.");
                    Console.WriteLine("");
                }
            }
        }
    }
}
