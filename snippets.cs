using System;
using System.Collections.Generic;
using System.Linq;

namespace Snippets
{
  using System.Numerics;

  class Program
  {
    static void Main(string[] args)
    {
      const int A = 2;
      const int B = 5;
      const int C = -4;
      const string D = "i have like 10 vowels.";
      BigInteger bigNumber = BigInteger.Parse("29090180355503362256910111038089984964854261893");
      string[] tokens = { "1", "10", "5", "2", "65", "11" };
      string[] blackJack = { "A", "3", "3", "3", "A"};
      //convert everything from string array to int array
      var numbers = Array.ConvertAll(tokens, int.Parse);

      var helper = new Helpers();
      helper.MinimumOfTwo(A, B);
      helper.MedianOfThree(A, B, C);
      helper.Rounding(B, A);
      helper.VowelCount(D);
      helper.FahrenheitToCelsius(-155);
      helper.SumOfDigits(1591);
      helper.DiceRolling(0.59558786964);
      helper.ReverseString(D);
      helper.WeightedSumOfDigits(1776);
      helper.Triangels(3, 4, 5);
      helper.ArrayChecksum(numbers);
      helper.ArrayCounters(numbers);
      helper.ArithmeticProgression(3, 0, 10);
      helper.Palindromes(D);
      helper.SortWithIndexes(numbers);
      helper.FindNumberInFibonacciSequel(bigNumber);
      helper.GreatestCommonDivisor(525,17645);
      helper.LeastCommonMultiple(20, 35);
      helper.FindTheLastRemainingPerson(36,3);
      helper.Int32ToBits(33);
      var testcase = helper.Blackjack(blackJack);
      Console.WriteLine(testcase);
      Console.ReadLine();
    }
  }




  public class Helpers
  {


    public int MinimumOfTwo(int a, int b)
    {
      return a < b ? a : b;
    }



    public int MedianOfThree(int a, int b, int c)
    {
      int[] numbers = { a, b, c };
      var result = 0;

      foreach (var t in numbers)
      {
        if (t != numbers.Max() && t != numbers.Min())
        {
          result = t;
        }
      }
      return result;
    }



    //Devive first by second and return number rounded to nearest integer.
    public int Rounding(int a, int b)
    {
      return Convert.ToInt32(Math.Round((decimal)a / b));
    }



    //counts the vowels in an input string
    public int VowelCount(string a)
    {
      var vowels = new[] { 'a', 'o', 'u', 'i', 'e', 'y' };
      var line = a.ToCharArray();
      return line.Sum(t => vowels.Count(t1 => t == t1));
    }



    public double FahrenheitToCelsius(int f)
    {
      return 5.0 / 9.0 * (f - 32);
    }



    //For example sum of 1001 is 1+0+0+1=2
    public int SumOfDigits(int sum)
    {
      var output = 0;
      while (sum != 0)
      {
        output += sum % 10;
        sum /= 10;
      }
      return output;
    }



    //simulation of dice rolling by the values coming from a random numbers generator. from 0 (inclusive) to 1 (not inclusive) 
    public int DiceRolling(double number)
    {
      double output = number * 6;
      int result = (int)output + 1;
      return result;
    }



    public char[] ReverseString(string input)
    {
      IEnumerable<char> reverse = input.ToCharArray().Reverse();
      return reverse.ToArray();
    }



    //How many times 1-s, 2-s, 3-s ... N-s (In that order) are encountered in an array. F.E 10 1-s, 20 2-s and so on.
    public string ArrayCounters(int[] numbers)
    {
      string result = string.Empty;
      var dictionary = new Dictionary<int, int>();
      foreach (int n in numbers)
      {
        if (!dictionary.ContainsKey(n))
        {
          dictionary[n] = 1;
        }
        else
        {
          dictionary[n]++;
        }
      }

      foreach (var number in dictionary.OrderBy(i => i.Key))
      {
        result = result + number.Value + " ";
      }
      return result;
    }



    //This program resembles more complex algorithms for calculation CRC and other checksums and also hash-functions on character strings.
    //F.E WeightedSumOfDigits => wsd(1776) = 1 * 1 + 7 * 2 + 7 * 3 + 6 * 4 = 60
    public int WeightedSumOfDigits(int number)
    {
      int output = 0;

      List<int> listOfInts = new List<int>();
      while (number > 0)
      {
        listOfInts.Add(number % 10);
        number = number / 10;
      }

      listOfInts.Reverse();

      int[] outputs = listOfInts.ToArray();

      for (int j = 0; j < outputs.Length; j++)
      {
        var temp = outputs[j] * (j + 1);
        output = output + temp;
      }

      return output;
    }



    //Check if 3 digits can form a triangel or not. 
    public bool Triangels(int a, int b, int c)
    {
      return a + b > c && c + a > b && c + b > a;
    }



    // check whether resulting array is correct or not
    //F.E any bank card you use has a checksum in the last digit of its number so any device could prevent you from entering wrong number by mistake 
    public long ArrayChecksum(int[] numbers)
    {
      var result = numbers.Aggregate(0L, (current, t) => (current + Convert.ToInt64(t)) * 113 % 10000007);
      return result;
    }



    //arithmetic sequence - series of numbers with a special property - each value is followed by the other, greater by predefined amount (step).
    //F.E: A + (A + B) + (A + 2B) + (A + 3B) + ...
    public int ArithmeticProgression(int firstValue, int step, int numberOfValues)
    {
      int output = 0;

      for (int x = 1; x < numberOfValues; x++)
      {
        output = output + (firstValue + step * x);
      }

      return output + firstValue;
    }



    public bool Palindromes(string test)
    {
      int start = 0;
      int end = test.Length - 1;

      while (true)
      {
        if (start > end)
        {
          return true;
        }

        char a = test[start];
        char b = test[end];
        if (char.ToLower(a) != char.ToLower(b))
        {
          return false;
        }

        start++;
        end--;
      }
    }



    public void SortWithIndexes(int[] numbers)
    {
      List<int> inputOriginal = numbers.ToList();
      int swaps = 0;
      int stop;
      string result = string.Empty;
      do
      {
        stop = swaps;
        for (int i = 0; i < numbers.Length - 1; i++)
        {
          if (numbers[i + 1] < numbers[i])
          {
            int temp = numbers[i];
            numbers[i] = numbers[i + 1];
            numbers[i + 1] = temp;
            swaps++;
            Console.WriteLine(string.Join(" ", numbers));
          }
        }
      } while (swaps != stop);
      Console.WriteLine("It took {0} swaps to sort the array.", swaps);
      foreach (var number in numbers)
      {
        //index starts normal at 0 we start with position 1.
        var index = inputOriginal.IndexOf(number) + 1;
        Console.WriteLine("Number {0} was at position {1} before.", number, index);
      }
    }



    public void FindNumberInFibonacciSequel(BigInteger number)
    {
      BigInteger[] fibonacciSequel = new BigInteger[10000];
      fibonacciSequel[0] = 0;
      fibonacciSequel[1] = 1;
      long result = 0;
      if (number == fibonacciSequel[0])
      {
        result = 0;
      }

      if (number == fibonacciSequel[1])
      {
        result = 1;
      }

      for (long j = 2; j < fibonacciSequel.Length; j++)
      {
        fibonacciSequel[0] = 0;
        fibonacciSequel[1] = 1;
        fibonacciSequel[j] = fibonacciSequel[j - 1] + fibonacciSequel[j - 2];

        if (number == fibonacciSequel[j])
        {
          result = j;
          break;
        }
      }
      Console.WriteLine("The Positon of {0} in FibonacciSequel is {1}", number, result);
    }



    public int GreatestCommonDivisor(int a, int b)
    {
      while (a != b)
      {
        if (a > b)
        {
          a -= b;
        }
        else
        {
          b -= a;
        }
      }
      int gcd = a;

      return gcd;
    }


    //of a and b is such an integer, that it is divisible by both of them (and is the smallest of all possible)
    public int LeastCommonMultiple(int a, int b)
    {
      int d = this.GreatestCommonDivisor(a, b);
      int lcm = a * b / d;

      return lcm;
    }

    public void FindTheLastRemainingPerson(int persons, int step)
    {
      var listOfPeople = new List<int>();

      for (int i = 0; i < persons; i++)
      {
        listOfPeople.Add(i + 1);
      }

      int counter = 0;
      while (listOfPeople.Count != 1)
      {
        counter = (counter + step - 1) % listOfPeople.Count;
        var person = listOfPeople[counter];
        listOfPeople.RemoveAt(counter);
        Console.WriteLine("Removed: " +  person);
      }
      Console.WriteLine("Winner: " + listOfPeople[0]);
    }

    public void Int32ToBits(int number)
    {
      int ones = 0;
      char[] bits = new char[32];
      int start = 0;
      int counter = 31;
      while (start < 32)
      {
        if ((number & (1 << start)) != 0)
        {
          bits[counter] = '1';
        }
        else
        {
          bits[counter] = 'O';
        }
        counter--;
        start++;
      }
      string result = new string(bits);
      Console.WriteLine("Number {0} looks like this: {1} in Binary.", number, result);
    }

    public string Blackjack(string [] input)
    {
      string answer = string.Empty;
      int score = 0;
      int ace = 0;

      foreach (var card in input)
      {
        switch (card)
        {
          case "T": case "J": case "Q": case "K":
            score = score + 10;
            break;
          case "A":         
            if (score >= 11)
            {
              score = score + 1;
            }
            else
            {
              score = score + 11;
            }
            ace++;
            break;
          default:
            score = score +  int.Parse(card);
            break;
        }
      }
      if (score > 21)
      {
        answer = answer + "Bust" + " ";
      }
      else
      {
        answer = answer + score + " ";
      }
      return answer;
    }
  }
}
