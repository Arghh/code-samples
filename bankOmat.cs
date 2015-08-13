using System;
using System.Globalization;


namespace BankOmant
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        int m;
        string sum;
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("How much would you like to take out today?");
        sum = Console.ReadLine();
        m = Int32.Parse(sum);
        
        if (m % 5 != 0)
        {
          Console.WriteLine("We only have 50€, 20€, 10€ and 5€ banknotes available");
          Console.WriteLine(m + " € is not a correct amount.");
        }

        else if (m < 0)
        {
          Console.WriteLine("You can't take out a negative sum of money.");
        }
    
        else
        {
          Helpers.calculator(m, 50);

          if (m >= 50)
          {
            Console.WriteLine("You received " + Helpers.calculator(m, 50) + " 50€");
          }

          if (Helpers.rest >= 20)
          {
            Console.WriteLine("You received " + Helpers.calculator(Helpers.rest, 20) + " 20€");
          }

          if (Helpers.rest >=10)
          {
            Console.WriteLine("You received " + Helpers.calculator(Helpers.rest, 10) + " 10€");
          }

          if (Helpers.rest >= 5)
          {
            Console.WriteLine("You received " + Helpers.calculator(Helpers.rest, 5) + " 5€");
          }

          Console.WriteLine("Have a nice day!");
        }
    }

    catch (FormatException e)
      {
        Console.WriteLine(e.Message);
      }
    }
  }

  class Helpers
  {
     
     public static int rest;
     public static int calculator(int x, int y) //math-> x = total sum, y = divided by 50,20,10 or 5. result = x % y. rest sum leftover out
        {
            int result = Math.DivRem(x, y, out rest); 
            return result;
        }
  }
}
