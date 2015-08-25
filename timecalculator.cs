using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace TimeCalculator
{
  class Program
  { 
    static void Main(string[] args)
    {     
      DateCalculator test = new DateCalculator();
      
      try
      { //userpick
        Console.WriteLine("Enter starting date");
        string StartTime = Console.ReadLine();
        DateTime start = Convert.ToDateTime(StartTime);
       
        Console.WriteLine("Enter ending date");
        string EndTime = Console.ReadLine();
        DateTime end = Convert.ToDateTime(EndTime);

        //call the methods
        test.Days(start, end);
        test.TotalLeapDays(start, end);
        test.FridayTheThirteenth(start, end);
        test.Roman(start, end);      
      }
      catch (FormatException)
      {
        Console.WriteLine("That is not a valid date.");
        Console.WriteLine("");
      }    
      Console.ReadLine();
    }
  }

  class DateCalculator
  {  
    public void Days(DateTime Start, DateTime End)
    {
      string starting = Start.ToString("yyyy-MM-dd");
      string ending = End.ToString("yyyy-MM-dd");
        var total = (End - Start).TotalDays;
        Console.WriteLine("There are {0} days between {1} and {2}.", total, starting, ending);
    }

    public void TotalLeapDays(DateTime Start, DateTime End)
    {
      int startYear = Start.Year;
      int endYear = End.Year;
      int leapDays = 0;
      for (int year = startYear; year <= endYear; year++)
      {
        if (DateTime.IsLeapYear(year))
          {
            leapDays++;
          }
      }
      Console.WriteLine("There are " + leapDays + " leap days between the year " + startYear + " and " + endYear);
    }

    public void FridayTheThirteenth(DateTime Start, DateTime End)
    {  
      int friday13ths = 0;
      var list = new List<DateTime>();
      var startTime = Start;
      while (Start <= End) 
      {      
        if (Start.Day == 13 && Start.DayOfWeek == DayOfWeek.Friday)
          {
            friday13ths++;
            list.Add(Start);           
          }
        
        Start = Start.AddDays(1);
      }

      Console.WriteLine("There are " + friday13ths + " Friday the 13ths between " + startTime.ToString("yyyy-MM-dd") + " and " + End.ToString("yyyy-MM-dd"));

      if (list.Count > 1)
      {
        int days = 0;
        int totaldays = 0;
        for (int i = 0; i < list.Count -1; i++)
        {
          int j = i + 1;
          days = (list[j].Date - list[i].Date).Days;
          totaldays += days;
          j++;
        }

        int average = totaldays / list.Count()-1;
       
        Console.WriteLine("The average time between 2 friday the 13ths is " + average + "days.");
      }
    }

    public void Roman(DateTime start, DateTime end)
    {
      StringBuilder result = new StringBuilder();
      int[] startingTimes = { start.Day, start.Month, start.Year };     
      int[] endingTimes = {end.Day, end.Month, end.Year};
      int[] digitsValues = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
      string[] romanDigits = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

      Console.Write("Start date in roman numbers: ");
      foreach (var i in startingTimes)
      { 
        Console.Write("{0} ",helper(i));
      }

      Console.WriteLine("");

      Console.Write("End date in roman numbers: ");
      foreach (var i in endingTimes)
      {
        Console.Write("{0} ",helper(i));
      }
    }

    private string helper(int x)
    {
      StringBuilder result = new StringBuilder();
      int[] digitsValues = { 1, 4, 5, 9, 10, 40, 50, 90, 100, 400, 500, 900, 1000 };
      string[] romanDigits = { "I", "IV", "V", "IX", "X", "XL", "L", "XC", "C", "CD", "D", "CM", "M" };

      while (x > 0)
      {
        for (int i = digitsValues.Count() - 1; i >= 0; i--)
          if (x / digitsValues[i] >= 1)
          {
            x -= digitsValues[i];
            result.Append(romanDigits[i]);
            break;
          }
      }
      return result.ToString();
    }
  }
}
