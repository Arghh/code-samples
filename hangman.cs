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

       static void play ()
        {
         int count = 0;
            int livesLeft = 11;
            int coursorMove = 0;
            List<char> guessed = new List<char>();
            Console.WriteLine("Enter a word for hangman:");
            char[] word = Console.ReadLine().ToCharArray();
            char[] dummy = new char[word.Length];
            Console.Clear();

            for (int x = 0; x < dummy.Length; x++)
            {
                dummy[x] = '_';
            }
            Console.WriteLine("Enter letters until you guess the word or run out of turns.");
            do
            {
                Console.WriteLine("");
                Console.SetCursorPosition(coursorMove,2);
                
                char a = Console.ReadKey().KeyChar;
                if (guessed.Contains(a))
                {
                    Console.WriteLine("");
                }
                else
                {
                    guessed.Add(a);
                    coursorMove++;
                    livesLeft = 10 - guessed.Count;
                    Console.WriteLine("");
                    for (int i = 0; i < word.Length; i++)
                    {
                        if (word[i] == a)
                        {
                            dummy[i] = a;
                            count++;
                            livesLeft++;
                        }
                        Console.Write(dummy[i] + " ");
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("You have " + livesLeft + " turns left."); 
                if (guessed.Count == 10)
                    break;
            } while (count < word.Length);

            if(count < word.Length)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You lost");
                Console.ResetColor();
                Console.Write("The word was:");
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
