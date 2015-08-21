using System;
using System.Collections.Generic;
using System.Linq;


namespace Lototron
{
  class Program
  {
    //new random nr
    private static Random rand;

    static void Main(string[] args)
    {
      while(true)
      {
        Console.WriteLine("Are you feeling lucky?");
        rand = new Random();
        int[] winningNumbers = new int[6];
        int[] userNumbers = new int[6];

        //usernr picker
        Console.WriteLine("Pick your 6 lucky numbers. From 1 to 49");
        for (int i = 0; i < userNumbers.Length; i++)
        {
          int userNumber;
          do
          {
            int show = i + 1;
            Console.Write("Please enter your " + show + " number:");
            string userPicks = Console.ReadLine();
            bool check = Int32.TryParse(userPicks, out userNumber);

          } while (userNumber < 1 || userNumber > 49 || userNumbers.Contains(userNumber));

          userNumbers[i] = userNumber;
        }

        //radom number picker for
        for (int idx = 0; idx < 6; idx++)
        {
          int proposedNumber;

          do
          {
            proposedNumber = rand.Next(1, 49);

          } while (winningNumbers.Contains(proposedNumber));

          winningNumbers[idx] = proposedNumber;
        }

        //show the numbers
        Console.WriteLine("Your 6 numbers are: ");
        foreach (var nr in userNumbers)
        {
          Console.Write(" " + nr + " ");
        }
        Console.WriteLine("");

        Console.WriteLine("Todays winning numbers are:");

        foreach (var nr in winningNumbers)
        {
          Console.Write(" " + nr + " ");
        }

        Console.WriteLine("");

        //compare usernrs with winning numbers
        int hit = 0;

        foreach (int a in userNumbers)
        {
          foreach (int b in winningNumbers)
          {
            if (a == b)
            {
              hit++;
            }
          }
        }

        //how well did user do
        decimal result = (decimal)hit / 6;
        if (hit > 0)
        {
          Console.WriteLine("You got {0} correct. Gratz! That is {1}.", hit, result.ToString("0%"));
        }
        else
        {
          Console.WriteLine("Better luck next time!");
        }
        Console.WriteLine("");
      }      
    }    
  }     
}
