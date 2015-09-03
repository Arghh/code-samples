using System;
using System.Collections.Generic;

namespace hangman
{
  class Program
  {
    static void Main()
    {
      bool asd = true;
      while (asd)
      {
        play();
      }
    }

    static void play()
    {
      int winCount = 0;
      int coursorMove = 0;
      int startingLives = 9;
      int guessesLeft = 0;
      int counter = 0;
      List<char> guessed = new List<char>();
      Console.WriteLine("Enter a word for hangman:");
      char[] word = Console.ReadLine().ToCharArray();
      char[] dummy = new char[word.Length];
      Console.Clear();

      for (int x = 0; x < dummy.Length; x++)
      {
        dummy[x] = '_';
      }
      Console.WriteLine("Enter letters until you guess the word or run out of lives.");
      do
      {
        Console.WriteLine("");
        Console.SetCursorPosition(coursorMove, 2);

        char a = Console.ReadKey().KeyChar;
        if (guessed.Contains(a))
        {
          Console.WriteLine(" ");
        }
        else
        {
          guessed.Add(a);
          coursorMove++;
          Console.WriteLine(" ");
          for (int i = 0; i < word.Length; i++)
          {
           
            if (word[i] == a)
            {
              guessed.Remove(a);
              dummy[i] = a;
              winCount++;
              counter++;
            }
            Console.Write(dummy[i] + " ");
          }
          
        }
        guessesLeft = startingLives - guessed.Count + winCount - (counter-1);
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("You have " + guessesLeft + " lives left.");
        if (guessed.Count == 10 + winCount)
          break;
      } while (winCount < word.Length);

      if (winCount < word.Length)
      {
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("You lost");
        Console.ResetColor();
        Console.Write("The word was: ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write(word);
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("");
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You won");
        Console.ResetColor();
      }
    }
  }
}
