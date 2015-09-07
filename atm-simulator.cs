using System;
using System.Collections.Generic;

namespace BankOMat3
{
  class Program
  {
    static void Main(string[] args)
    {
      //TODO depsoit how many of what.
      Console.OutputEncoding = System.Text.Encoding.UTF8;

      //list of ATMs
      List<BankAutomat> atms = new List<BankAutomat>();

      //new ATM-s
      var automat1 = new BankAutomat("ATM 1", 10, 20, 50, 100);
      var automat2 = new BankAutomat("ATM 2", 2, 3, 4, 5);
      var automat3 = new BankAutomat("ATM 3", 10, 20, 30, 40);
      atms.Add(automat1);
      atms.Add(automat2);
      atms.Add(automat3);

      //general info of the ATMs
      foreach (var automat in atms)
      {
        Console.WriteLine("Starting info: {0} has {1} € in it.", automat.GetName(), automat.MoneyInside());
      }

      //userinterface
      string UserChoice = "";
      Console.WriteLine("How may we help you today?");
      while (UserChoice != "1" || UserChoice != "2" || UserChoice != "3") //loop so long until user picks correctly
      {
        Console.WriteLine("Press 1 to withdraw money.");
        Console.WriteLine("Press 2 to deposit money.");
        Console.WriteLine("Press 3 to check the available funds in " + automat2.GetName());
        UserChoice = Console.ReadLine();

        switch (UserChoice)
        {
          case "1":
            try
            {
              Console.WriteLine("How much money would you like to withdraw?");
              string UserSum = Console.ReadLine();
              int amount = Int32.Parse(UserSum);
              Console.WriteLine(automat2.Withdraw(amount)); //call the withdraw method with int32 amount on chosen ATM.
              Console.WriteLine("");
            }
            catch (FormatException)
            {
              Console.WriteLine("This is an ATM not a toy.");
              Console.WriteLine("");
            }
            break;

          case "2":
            try
            {
              Console.WriteLine("How much money would you like to deposit?");
              string UserSum = Console.ReadLine();
              int amount = Int32.Parse(UserSum);
              Console.WriteLine(automat2.Deposit(amount)); //call the deposit method with int32 amount on chosen ATM.
              Console.WriteLine("");
            }
            catch (FormatException)
            {
              Console.WriteLine("This is an ATM not a toy.");
              Console.WriteLine("");
            }
            break;

          case "3":
            Console.WriteLine(automat2.GetName() + " has " + automat2.BanknotesLeft());
            Console.WriteLine("Total money available: " + automat2.MoneyInside() + " €.");
            break;

          default:
            Console.WriteLine("");
            Console.WriteLine("Invalid selection. Please select 1, 2, or 3.");
            Console.WriteLine("");
            break;
        }
      }
    }
  }

  class BankAutomat
  {
    //Constructor
    public BankAutomat(string Name, int InFifties, int InTwenties, int InTens, int InFives)
    {
      this.name = Name;
      this.fifties = InFifties;
      this.twenties = InTwenties;
      this.tens = InTens;
      this.fives = InFives;
      this.total = (this.fifties * 50) + (this.twenties * 20) + (this.tens * 10) + (this.fives * 5);
    }

    //declearing the variables
    private string name;
    private int fifties;
    private int twenties;
    private int tens;
    private int fives;
    private int total;

    //methods
    public bool Check(int x)
    {
      if (x <= 0)
      {
        return false;
      }
      return true;
    }


    public bool Withdraw(int amount)
    {
      if (amount <= 0)
      {
        Console.WriteLine("Invalid amount.");
        return false;
      }
      else if (amount % 5 != 0)
      {
        Console.WriteLine("We only have 50€, 20€, 10€ and 5€ banknotes available.");
        Console.WriteLine(amount + " € is not a correct amount.");
        return false;
      }
      else if (amount > this.total)
      {
        Console.WriteLine("Sorry {0} does that have {1} € to withdraw. Please try one of our other ATMs.", GetName(), amount);
        return false;
      }
      else
      {
        //check if there are fifties, twenties etc. true/false.
        //when true f.e fifties: amount - 50, fifties - 1. repeat. 
        //how many fiftiesrecieved gets printed out if 0 then not
        this.total -= amount;
        if (Check(fifties))
        {
          int fiftiesRecieved = 0;
          while (fifties > 0)
          {
            if (amount < 50)
            { break; }
            amount -= 50;
            fifties -= 1;
            fiftiesRecieved++;
          }
          if (fiftiesRecieved > 0)
          {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You received " + fiftiesRecieved + " X 50 €.");
            Console.ResetColor();
          }
        }

        if (Check(twenties))
        {
          int twentiesRecieved = 0;
          while (twenties > 0)
          {
            if (amount < 20)
            { break; }
            amount -= 20;
            twenties -= 1;
            twentiesRecieved++;
          }
          if (twentiesRecieved > 0)
          {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You received " + twentiesRecieved + " X 20 €.");
            Console.ResetColor();
          }
        }

        if (Check(tens))
        {
          int tensRecieved = 0;
          while (tens > 0)
          {
            if (amount < 10)
            { break; }
            amount -= 10;
            tens -= 1;
            tensRecieved++;
          }
          if (tensRecieved > 0)
          {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You received " + tensRecieved + " X 10 €.");
            Console.ResetColor();
          }
        }

        if (Check(fives))
        {
          int fivesRecieved = 0;
          while (fives > 0)
          {
            if (amount < 5)
            { break; }
            amount -= 5;
            fives -= 1;
            fivesRecieved++;
          }
          if (fivesRecieved > 0)
          {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You received " + fivesRecieved + " X 5 €.");
            Console.ResetColor();
          }
        }
        Console.WriteLine("");
        Console.WriteLine("Have a nice day!");
        return true;
        

      }
    }

    public bool Cash(int x)
    {
      if (x <= 0)
      {
        return false;
      }
      return true;
    }


    public bool Deposit(int amount)
    {
      if (amount <= 0 || amount % 5 != 0)
      {
        Console.WriteLine("You can't deposit that amount of money.");
        return false;
      }

      else
      {
        //adds only to total amount. does not increase the amount of fifties, twenties etc in ATM. does not make sense
        this.total += amount;
        Console.WriteLine("You deposited {0} €", amount);
        return true;       
      }
    }


    public int MoneyInside()
    {
      return this.total;
    }


    public string BanknotesLeft()
    {
      return fifties.ToString() + " 50€," + twenties.ToString() + " 20€," + tens.ToString() + " 10€ and " + fives.ToString() + " 5€ banknotes available.";
    }


    public string GetName()
    {
      return this.name;
    }
  }
}
