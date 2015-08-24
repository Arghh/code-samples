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

      var culture = new CultureInfo("en-US");
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
      double total = (End - Start).TotalDays;
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

      while (Start <= End)
      {
        if (Start.Day == 13 && Start.DayOfWeek == DayOfWeek.Friday)
        {
          friday13ths++;
          list.Add(Start);
        }
        Start = Start.AddDays(1);
      }

      Console.WriteLine("There are " + friday13ths + " Friday the 13ths between " + Start.AddDays(-1).ToString("yyyy-MM-dd") + " and " + End.ToString("yyyy-MM-dd"));

      if (list.Count > 1)
      {
        var diff = list.Max().Subtract(list.Min());
        var avgTime = TimeSpan.FromDays(diff.TotalDays / list.Count() - 1);
        int avgTimeInDays = avgTime.Days;
        Console.WriteLine("The average time between 2 friday the 13ths is " + avgTimeInDays + " days.");
      }
    }
  }
}
